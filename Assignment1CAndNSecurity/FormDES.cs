using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Diagnostics;
namespace Assignment1CAndNSecurity
{

    public partial class FormDES : Form
    {
        public FormDES()
        {
            InitializeComponent();
        }

        bool isEncryptFile = true;
        private string inputFileName, outputFileName = "", mode;
        private string key;

        private void FormDES_Load(object sender, EventArgs e)
        {
            comboBoxMode.Items.Add("CBC");
            comboBoxMode.Items.Add("ECB");
            comboBoxMode.Items.Add("CFB");

            comboBoxMode.Text = "CBC";

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.Update();

            this.progressBar2.Visible = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Open file.
        private void btnOpenIn_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = true;
            this.tbOutput.Clear();
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                tbInput.Text = op.FileName;
        }

        //Open folder.
        private void btnOpenFolderIn_Click(object sender, EventArgs e)
        {
            this.isEncryptFile = false;
            this.tbOutput.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.tbInput.Text = folderBrowserDialog1.SelectedPath;
        }

        /*
         * DES Algorithm contains both the encryption and decryption.
         * DESAlgorithm ( <string> input file name, <string> output file name, <string> key ,<string> mode=CBC or ECB or CFB , <bool> is the process Encryption? )
         * EX: DESAlgorithm("C:\thienphuoc.png","C:\thienphuoc.png.tpEn","thienphuoc","CBC",true)
         */
        void DESAlgorithm(string sInputFilename, string sOutputFilename, string sKey, string mode, bool isEncrypt)
        {

            byte[] bytes = Convert.FromBase64String(sKey); //Key 8 bytes = 64bits.

            //Open the input file and create the output file.
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsOutput = new FileStream(sOutputFilename, FileMode.OpenOrCreate, FileAccess.Write);
            fsOutput.SetLength(0);

            //Each reading 100bytes.
            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fsInput.Length;//Total length.
            int len;

            //Set parameter for progress bar.
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)fsInput.Length;

            //DES 
            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            //Set mode for DES Algorithm.
            if (mode == "ECB") DES.Mode = CipherMode.ECB;
            else if (mode == "CBC") DES.Mode = CipherMode.CBC;
            else if (mode == "CFB") DES.Mode = CipherMode.CFB;

            //Encrypting
            CryptoStream encStream;

            if (isEncrypt)
                encStream = new CryptoStream(fsOutput, DES.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            else
                encStream = new CryptoStream(fsOutput, DES.CreateDecryptor(bytes, bytes), CryptoStreamMode.Write);


            //Read from the input file ,each reading 100 bytes,then encrypted and written to the output file.
            while (rdlen < totlen)
            {
                len = fsInput.Read(bin, 0, 100);//Each reading 100bytes
                encStream.Write(bin, 0, len);
                progressBar1.Value = (int)rdlen;
                rdlen = rdlen + len;
                this.progressBar1.PerformStep();
            }


            if (progressBar1.IsHandleCreated && isEncryptFile)
            {
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = Path.GetDirectoryName(outputFileName);
                prc.Start();
                //MessageBox.Show("Mã hóa thành công!");
            }

            // Close all files.
            encStream.Close();
            fsOutput.Close();
            fsInput.Close();
        }

        /**
         * Button Encrypt.
         */
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            

            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
                Strings.Len(Strings.Trim(tbKey.Text)) != 0 &&
                Strings.Len(Strings.Trim(comboBoxMode.Text)) != 0)
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                this.inputFileName = tbInput.Text;             //get Input file.
                this.outputFileName = tbInput.Text + ".tpEn";  //set Output file.
                if(isEncryptFile)
                    this.tbOutput.Text = outputFileName;           //
                
                this.mode = comboBoxMode.Text;                 //get Mode.
                this.key = tbKey.Text;                         //get Key. (base64String)

                if (isEncryptFile) // Encrypt 1 file.
                    DESAlgorithm(this.inputFileName, this.outputFileName, this.key, this.mode, true);
                else
                {
                    //get all files from path.
                    string[] filePaths = Directory.GetFiles(inputFileName);

                    if (filePaths.Length == 1 && (Path.GetFileName(filePaths[0]) == "Thumbs.db"))
                    {
                        MessageBox.Show("Thư mục rỗng!");
                        return;
                    }

                    if (filePaths.Length == 0)
                    {
                        MessageBox.Show("Thư mục rỗng!");
                        return;
                    }

                    //Set parameter for progressBar2.
                    this.progressBar2.Visible = true;
                    this.progressBar2.Minimum = 0;
                    this.progressBar2.Maximum = filePaths.Length;

                    if (filePaths.Length > 0)
                    { 
                        this.outputFileName = filePaths[0];
                        this.tbOutput.Text = outputFileName;   
                    }


                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        progressBar2.Value = i;

                        if (Path.GetFileName(filePaths[i]) != "Thumbs.db")
                            DESAlgorithm(filePaths[i], filePaths[i] + ".tpEn", this.key, this.mode, true);

                        this.progressBar2.PerformStep();
                    }


                    if (progressBar2.IsHandleCreated)
                    {
                        System.Diagnostics.Process prc = new System.Diagnostics.Process();
                        prc.StartInfo.FileName = Path.GetDirectoryName(filePaths[0]);
                        prc.Start();
                    }

                }
                sw.Stop();
                double elapsedMs = sw.Elapsed.TotalMilliseconds/1000;
                MessageBox.Show("Thời gian thực thi "+elapsedMs.ToString()+"s");
            }
            else
            {
                MessageBox.Show("Dữ liệu không đủ để mã hóa!");
            }
            
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider) DESCryptoServiceProvider.Create();
            tbKey.Text = Convert.ToBase64String(desCrypto.Key);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
                Strings.Len(Strings.Trim(tbKey.Text)) != 0 &&
                Strings.Len(Strings.Trim(comboBoxMode.Text)) != 0
                )
            {
                this.inputFileName = tbInput.Text;
                
                

                this.outputFileName = tbInput.Text;
                if (isEncryptFile)
                {
                    if (Path.GetExtension(this.inputFileName) != ".tpEn") {
                        MessageBox.Show("File này không được hỗ trợ để giã mã!");
                        return;
                    }
                    this.outputFileName = this.outputFileName.Substring(0, this.outputFileName.Length - 5);
                    this.tbOutput.Text = outputFileName;
                }
                this.mode = comboBoxMode.Text;
                this.key = tbKey.Text;                         //get Key.

                if (isEncryptFile) // Encrypt 1 file.
                    DESAlgorithm(this.inputFileName, this.outputFileName, this.key, this.mode, false); 
                else
                {
                    //Get all files ".tpEn" from path.
                    string[] filePaths = Directory.GetFiles(inputFileName, "*.tpEn");

                    if (filePaths.Length == 0)
                    {
                        MessageBox.Show("Thư mục không có chứa file dạng .tpEn!");
                        return;
                    }

                    //Set parameter for progressBar2.
                    this.progressBar2.Visible = true;
                    this.progressBar2.Minimum = 0;
                    this.progressBar2.Maximum = filePaths.Length;

                    this.outputFileName = filePaths[0];
                    this.tbOutput.Text = this.outputFileName;

                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        progressBar2.Value = i;
                        DESAlgorithm(filePaths[i], filePaths[i].Substring(0,filePaths[i].Length-5), this.key, this.mode, false);
                        this.progressBar2.PerformStep();
                    }

                    //Auto open folder.
                    if (progressBar2.IsHandleCreated)
                    {
                        System.Diagnostics.Process prc = new System.Diagnostics.Process();
                        prc.StartInfo.FileName = Path.GetDirectoryName(filePaths[0]);
                        prc.Start();
                    }

                }

            }
            else
            {
                MessageBox.Show("Dữ liệu không đủ để giải mã!");
            }
        }

        private void btnOutOpen_Click(object sender, EventArgs e)
        {
            if (this.outputFileName.Length > 0)
            {
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = Path.GetDirectoryName(outputFileName);
                prc.Start();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbKey.Clear();
            this.tbInput.Clear();
            this.tbOutput.Clear();
            this.comboBoxMode.Text = "CBC";
            this.outputFileName = "";
            this.inputFileName = "";
            if (this.progressBar1.Value > 0)
                this.progressBar1.Value = 0;
            this.progressBar2.Visible = false;
            MessageBox.Show("Reset successful!");
        }



        //II.Part make up UI
        private void btnGenerateKey_MouseHover(object sender, EventArgs e)
        {
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
        }

        private void btnGenerateKey_MouseLeave(object sender, EventArgs e)
        {
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
        }

        private void btnGenerateKey_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
        }

        private void btnOpenFileIn_MouseHover(object sender, EventArgs e)
        {
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFileIn_MouseLeave(object sender, EventArgs e)
        {
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;

        }

        private void btnOpenFileIn_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFolderIn_MouseHover(object sender, EventArgs e)
        {
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
        }

        private void btnOpenFolderIn_MouseLeave(object sender, EventArgs e)
        {
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
        }

        private void btnOpenFolderIn_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
        }

        private void btnOutOpen_MouseHover(object sender, EventArgs e)
        {
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
        }

        private void btnOutOpen_MouseLeave(object sender, EventArgs e)
        {
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
        }

        private void btnOutOpen_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
        }

        private void btnEncrypt_MouseHover(object sender, EventArgs e)
        {
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
        }

        private void btnEncrypt_MouseLeave(object sender, EventArgs e)
        {
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
        }

        private void btnEncrypt_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
        }

        private void btnDecrypt_MouseHover(object sender, EventArgs e)
        {
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
        }

        private void btnDecrypt_MouseLeave(object sender, EventArgs e)
        {
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
        }

        private void btnDecrypt_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }
    }
}
