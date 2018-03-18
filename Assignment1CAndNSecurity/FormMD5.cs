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
using System.Security.Cryptography;

namespace Assignment1CAndNSecurity
{
    public partial class FormMD5 : Form
    {
        public FormMD5()
        {
            InitializeComponent();
        }

        bool isEncryptFile=true;

        private void FormMD5_Load(object sender, EventArgs e)
        {
            this.comboBox2.Items.Add("File");
            this.comboBox2.Items.Add("Text");

            this.comboBox2.Text = "File";
            this.isEncryptFile = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_en_brow_md5_Click(object sender, EventArgs e)
        {
            //txt_en_md5.Text = "";
            openFileDialog1.Filter = "All Files (*.*)|*.*";
            openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txt_en_brow_md5.Text = openFileDialog1.FileName;
            }
        }

        private String openfile()
        {
            FileStream fs = new FileStream(txt_en_brow_md5.Text, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            string str = "";
            int blocksize = 4 * 1024;
            int iteration_number;
            if (fs.Length < blocksize)
                iteration_number = 1;
            else if (fs.Length % blocksize == 0)
                iteration_number = (int)fs.Length / blocksize;
            else
                iteration_number = ((int)fs.Length / blocksize) + 1;
            while (iteration_number-- > 0)
            {
                if (iteration_number == 0)
                    blocksize = (int)fs.Length % blocksize;
                byte[] input = br.ReadBytes(8);
                for (int i = 0; i < input.Length; i++)
                {
                    str = str + input[i];
                }
            }
            br.Close();
            return str;
        }
        private string GetMD5HashData(string data)
        {
            //create new instance of md5
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] hashData = md5.ComputeHash(ASCIIEncoding.Default.GetBytes(data));
            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }
            return returnValue.ToString();
        }

        private void btn_en_md5_Click_1(object sender, EventArgs e)
        {
            try
            {
                txt_en_md5.Text = GetMD5HashData(openfile());
                MessageBox.Show("Encryption succeeded");

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
                MessageBox.Show("Encryption failed");
            }
        }

        private void btn_en_md5_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox2.Text == "File")
                {
                    txt_en_md5.Text = GetMD5HashData(openfile());


                }
                else
                {
                    txt_en_md5.Text = GetMD5HashData(txt_en_brow_md5.Text);
                }
                MessageBox.Show("Encryption succeeded");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Encryption failed " +ex.Message);
            }
        }
    }
}
