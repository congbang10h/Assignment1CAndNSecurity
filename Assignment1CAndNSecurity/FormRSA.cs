using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Xml;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Assignment1CAndNSecurity
{
    public partial class FormRSA : Form
    {
        public FormRSA()
        {
            InitializeComponent();
        }

        private RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        private RSACryptoServiceProvider RSA2 = new RSACryptoServiceProvider(2048);  
        private string pathKeysXML = "";
        private string publicKeyFile = "C:/Users/phanhien/Desktop/Assignment1CAndNSecurity/Assignment1CAndNSecurity/bin/Debug/publicKey.xml";
        private string privateKeyFile = "C:/Users/phanhien/Desktop/Assignment1CAndNSecurity/Assignment1CAndNSecurity/bin/Debug/privateKey.xml";


        private void RSA_Algorithm(string inputFile, string outputFile, RSAParameters RSAKeyInfo, bool isEncrypt)
        {

            FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            FileStream fsCiperText = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            fsCiperText.SetLength(0);

            byte[] bin, encryptedData;
            long rdlen = 0;
            long totlen = fsInput.Length;
            int len;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum =(int)totlen;

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.ImportParameters(RSAKeyInfo);

            int maxBytesCanEncrypted;
            if (isEncrypt)
                maxBytesCanEncrypted = ((RSA.KeySize - 384) / 8) + 37;
            else
                maxBytesCanEncrypted = RSA.KeySize / 8;

            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen)
            {
                bin = new byte[maxBytesCanEncrypted];
                len = fsInput.Read(bin, 0, maxBytesCanEncrypted);

                if (isEncrypt) encryptedData = RSA.Encrypt(bin, false);
                else encryptedData = RSA.Decrypt(bin, false);

                fsCiperText.Write(encryptedData, 0, encryptedData.Length);
                rdlen = rdlen + len;

                this.progressBar1.Value = (int)rdlen;
                this.progressBar1.PerformStep();

            }

            fsCiperText.Close();
            fsInput.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRSA_Load(object sender, EventArgs e)
        {
            this.comboBoxLengKey.Items.Add("512bits");
            this.comboBoxLengKey.Items.Add("1024bits");
            this.comboBoxLengKey.Items.Add("2048bits");
            this.comboBoxLengKey.Items.Add("4096bits");

            this.comboBoxLengKey.Text = "1024bits";
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            
            using(var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    MessageBox.Show(fbd.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    publicKeyFile = fbd.SelectedPath + "/publicKey.xml";
                    privateKeyFile = fbd.SelectedPath + "/privateKey.xml";

                    generateKeys(publicKeyFile, privateKeyFile);
                }
            }

        }

        private void btnOpenFileKeys_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pathKeysXML = op.FileName;
                tbPathKeys.Text = op.FileName; 
            }


            if (File.Exists(pathKeysXML))
            {
                   

                if (Path.GetExtension(pathKeysXML) == ".xml")
                {
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(File.ReadAllText(pathKeysXML));
                    try {
                        XmlNode xnList = xml.SelectSingleNode("/RSAKeyValue/Modulus");
                        tbN.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/Exponent");
                        tbE.Text = xnList.InnerText;
                        xnList = xml.SelectSingleNode("/RSAKeyValue/D");
                        tbD.Text = xnList.InnerText;
                    }
                    catch { }
                }
            }
                 

        }

        private void btnOpenFolderIn_Click(object sender, EventArgs e)
        {

        }
        private void btnOpenFileIn_Click(object sender, EventArgs e)
        {
            this.tbOutput.Clear();
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                tbInput.Text = op.FileName;
        }


        private void btnOutOpen_Click(object sender, EventArgs e)
        {

        }

        private static void generateKeys(string publicKeyFile, string privateKeyFile)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                if (File.Exists(privateKeyFile))
                    File.Delete(privateKeyFile);
                if (File.Exists(publicKeyFile))
                    File.Delete(publicKeyFile);
                string publicKey = rsa.ToXmlString(false);
                File.WriteAllText(publicKeyFile, publicKey);
                string privateKey = rsa.ToXmlString(true);
                File.WriteAllText(privateKeyFile, privateKey);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
              if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
                Strings.Len(Strings.Trim(tbPathKeys.Text)) != 0 &&
                Strings.Len(Strings.Trim(tbN.Text)) != 0) { 
                  
                  string inputFile = tbInput.Text;
                  string outputFile = inputFile+".tpEn";
                  RSA = new RSACryptoServiceProvider();
                  RSA.FromXmlString(File.ReadAllText(this.pathKeysXML));
                  RSA_Algorithm(inputFile, outputFile, RSA.ExportParameters(true), true);
                  tbOutput.Text = outputFile;
              }
              else 
              {
                  MessageBox.Show("Không đủ điều kiện để mã hóa!");
              }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (Strings.Len(Strings.Trim(tbInput.Text)) != 0 &&
               Strings.Len(Strings.Trim(tbPathKeys.Text)) != 0 &&
               Strings.Len(Strings.Trim(tbN.Text)) != 0)
            {
                string inputFile = tbInput.Text;
                string outputFile = inputFile.Substring(0,inputFile.Length-5);
                RSA = new RSACryptoServiceProvider();
                RSA.FromXmlString(File.ReadAllText(this.pathKeysXML));
                RSA_Algorithm(inputFile, outputFile, RSA.ExportParameters(true), false);
                tbOutput.Text = outputFile;
            }
            else
            {
                MessageBox.Show("Không đủ điều kiện để giải mã !");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
        }
        /*
            II.Part make up UI*****************************************************
            */
        private void btnGenerateKey_MouseHover(object sender, EventArgs e)
        {
            //this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
        }

        private void btnGenerateKey_MouseLeave(object sender, EventArgs e)
        {
            //this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerate;
        }

        private void btnGenerateKey_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnGenerateKey.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnGenerateSelected;
        }

        private void btnOpenFileIn_MouseHover(object sender, EventArgs e)
        {
            //this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFileIn_MouseLeave(object sender, EventArgs e)
        {
            //this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;

        }

        private void btnOpenFileIn_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnOpenFileIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFolderIn_MouseHover(object sender, EventArgs e)
        {
            //this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
        }

        private void btnOpenFolderIn_MouseLeave(object sender, EventArgs e)
        {
            //this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolder;
        }

        private void btnOpenFolderIn_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnOpenFolderIn.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFolderSelected;
        }

        private void btnOutOpen_MouseHover(object sender, EventArgs e)
        {
            //this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
        }

        private void btnOutOpen_MouseLeave(object sender, EventArgs e)
        {
            //this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpen1;
        }

        private void btnOutOpen_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnOutOpen.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenSeleted;
        }

        private void btnReset_MouseHover(object sender, EventArgs e)
        {
            //this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            //this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnReset2;
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnReset.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnResetSelected;
        }

        private void btnEncrypt_MouseHover(object sender, EventArgs e)
        {
            //this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
        }

        private void btnEncrypt_MouseLeave(object sender, EventArgs e)
        {
            //this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncrypt3;
        }

        private void btnEncrypt_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnEncrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnEncryptSelected;
        }

        private void btnDecrypt_MouseHover(object sender, EventArgs e)
        {
            //this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
        }

        private void btnDecrypt_MouseLeave(object sender, EventArgs e)
        {
            //this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecrypt;
        }

        private void btnDecrypt_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnDecrypt.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDecryptSelected;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            //this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            //this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
        }

        private void btnExit_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExitSelected;
        }
        
        private void btnOpenFileKeys_MouseHover(object sender, EventArgs e)
        {
            //this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

        private void btnOpenFileKeys_MouseLeave(object sender, EventArgs e)
        {
            //this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFile;
        }

        private void btnOpenFileKeys_MouseMove(object sender, MouseEventArgs e)
        {
            //this.btnOpenFileKeys.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnOpenFileSeleted;
        }

    }
}
