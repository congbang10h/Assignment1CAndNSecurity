using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {  
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            
                if (comboBoxKLen.Text == "128bit")
                {
                    aes.KeySize = 128;
                }
                else if (comboBoxKLen.Text == "192bit")
                {
                    aes.KeySize = 192;
                }
                else { 
                    aes.KeySize = 256;
                }
                aes.GenerateKey();
                textBoxKey.Text = Convert.ToBase64String(aes.Key);
                MessageBox.Show( "Key Đã được tạo");
            

        }

       

        private void btnOpFile_Click(object sender, EventArgs e)
        {
            
            // Displays an OpenFileDialog so the user can select a file.  
               OpenFileDialog openFileDialog1 = new OpenFileDialog();  
               openFileDialog1.Filter = "All Files|*.*";  
               openFileDialog1.Title = "Select a Encrypt File";  

               // Show the Dialog.  
               // If the user clicked OK in the dialog and  
               // a file was selected, open it.  
               if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                   // Assign the cursor in the Stream to the Form's Cursor property.  
                   //this.Cursor = new Cursor(openFileDialog1.OpenFile());
                   textBoxInput.Text = openFileDialog1.FileName;
               }
        }
        private void btnOpFolder_Click(object sender, EventArgs e)
        {      
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.textBoxInput.Text = folderBrowserDialog1.SelectedPath;

        }
        private void AES(String key, String inputFile, String outputFile, String mode, bool EnAndDe)
        {

            FileStream Plaintext = new FileStream(inputFile, FileMode.Open, FileAccess.Read); ///Open file contain plantext
            FileStream CipherText = new FileStream(outputFile, FileMode.Create, FileAccess.Write); ///Open file contain cyphertext
            CipherText.SetLength(0);

            AesCryptoServiceProvider aesSymmetric = new AesCryptoServiceProvider();
            aesSymmetric.Key = Convert.FromBase64String(key);
            aesSymmetric.IV = ASCIIEncoding.ASCII.GetBytes(key.Substring(0, 16));
            ///Check mode 
            if (mode == "ECB") aesSymmetric.Mode = CipherMode.ECB;
            else if (mode == "CBC") aesSymmetric.Mode = CipherMode.CBC;
            else if (mode == "CFB") aesSymmetric.Mode = CipherMode.CFB;

            CryptoStream cryptStream;
            //Check the encrypt or decrypt
            if (EnAndDe)
                cryptStream = new CryptoStream(CipherText, aesSymmetric.CreateEncryptor(), CryptoStreamMode.Write); // encrypt
            else
                cryptStream = new CryptoStream(CipherText, aesSymmetric.CreateDecryptor(), CryptoStreamMode.Write);// decrypt

            //Read from the input file, then encrypt and write to the output file.
            byte[] bin;
            int count;
           /* FileInfo FileVol = new FileInfo(inputFile);
            string fileLength = FileVol.Length.ToString();
            string length = string.Empty;
            if (FileVol.Length >= (1 << 100))
            {

                bin = new byte[100];
                count = 10;
                
            }
            else {
                bin = new byte[100];
                count = 10;
            }*/
            bin = new byte[100];
            count = 100;
            long readcursor = 0;
            int step;
            
            progressBar1.Minimum = 0;
            progressBar1.Maximum =  (int)Plaintext.Length;
            while (readcursor < progressBar1.Maximum)
            {
                step = Plaintext.Read(bin, 0, count);


                cryptStream.Write(bin, 0, step);
                this.progressBar1.Value = (int)readcursor;
                readcursor = readcursor + step;
                this.progressBar1.PerformStep();

            }
            progressBar1.Value = progressBar1.Maximum;

            if (progressBar1.IsHandleCreated)
            {
                System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                process1.StartInfo.FileName = Path.GetDirectoryName(textBoxOuput.Text);
                process1.Start();
               
            }

            cryptStream.Close();
            Plaintext.Close();
            CipherText.Close();

        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.textBoxKey.Clear();
            this.textBoxInput.Clear();
            this.textBoxOuput.Clear();
            this.comboBoxKLen.Text = "128bit";
            this.comboBoxMode.Text = "EBC";
            this.progressBar1.Value = 0;
            if (this.progressBar1.Value > 0)
                this.progressBar1.Value = 0;
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;
            if (textBoxInput.TextLength != 0 && textBoxKey.TextLength != 0 && textBoxOuput.TextLength != 0)
            {
                
                AES(textBoxKey.Text , textBoxInput.Text, textBoxOuput.Text,  comboBoxMode.Text,true);
                
            }
            else{
                MessageBox.Show("Nhập đủ key và file input và nơi lưu dữ liệu ouput ");
            }
        }
        private void btnDe_Click(object sender, EventArgs e)

        {
            this.progressBar1.Value = 0;
            if (textBoxInput.TextLength != 0 && textBoxKey.TextLength != 0 && textBoxOuput.TextLength != 0)
            {
               
                /*this.textBoxOuput.Text = textBoxInput.Text.Substring(0, textBoxInput.Text.Length - 4) ;*/
                AES(textBoxKey.Text, textBoxInput.Text, textBoxOuput.Text, comboBoxMode.Text, false);
                
            }
            else
            {
                MessageBox.Show("Nhập đủ key và file input và nơi lưu dữ liệu ouput");
            }
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenOut_Click(object sender, EventArgs e)
        {
             if (folderBrowserDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 this.textBoxOuput.Text = folderBrowserDialog2.SelectedPath;
                string path = Path.GetDirectoryName(textBoxInput.Text);/// get directory  folder contain file input
                this.textBoxOuput.Text = textBoxOuput.Text + textBoxInput.Text.Substring(path.Length, textBoxInput.TextLength - path.Length ); /// get name file input conect with path of ouput
         
            
        }

        
       
    }
}
