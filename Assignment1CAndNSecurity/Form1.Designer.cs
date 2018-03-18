using System.Drawing;
namespace Assignment1CAndNSecurity
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnEncryption = new System.Windows.Forms.PictureBox();
            this.btnDecryption = new System.Windows.Forms.PictureBox();
            this.btnAES = new System.Windows.Forms.PictureBox();
            this.btnDES = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEncryption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecryption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDES)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnExit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(1032, 547);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(207, 177);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            this.btnExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseMove);
            // 
            // btnEncryption
            // 
            this.btnEncryption.BackColor = System.Drawing.Color.Transparent;
            this.btnEncryption.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnRSANon;
            this.btnEncryption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEncryption.Location = new System.Drawing.Point(749, 380);
            this.btnEncryption.Name = "btnEncryption";
            this.btnEncryption.Size = new System.Drawing.Size(207, 177);
            this.btnEncryption.TabIndex = 2;
            this.btnEncryption.TabStop = false;
            this.btnEncryption.Click += new System.EventHandler(this.btnEncryption_Click);
            this.btnEncryption.MouseLeave += new System.EventHandler(this.btnEncryption_MouseLeave);
            this.btnEncryption.MouseHover += new System.EventHandler(this.btnEncryption_MouseHover);
            this.btnEncryption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEncryption_MouseMove);
            // 
            // btnDecryption
            // 
            this.btnDecryption.BackColor = System.Drawing.Color.Transparent;
            this.btnDecryption.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnMD5Non;
            this.btnDecryption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecryption.Location = new System.Drawing.Point(673, 563);
            this.btnDecryption.Name = "btnDecryption";
            this.btnDecryption.Size = new System.Drawing.Size(207, 177);
            this.btnDecryption.TabIndex = 3;
            this.btnDecryption.TabStop = false;
            this.btnDecryption.Click += new System.EventHandler(this.btnDecryption_Click);
            this.btnDecryption.MouseLeave += new System.EventHandler(this.btnDecryption_MouseLeave);
            this.btnDecryption.MouseHover += new System.EventHandler(this.btnDecryption_MouseHover);
            this.btnDecryption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDecryption_MouseMove);
            // 
            // btnAES
            // 
            this.btnAES.BackColor = System.Drawing.Color.Transparent;
            this.btnAES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnAESNon;
            this.btnAES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAES.Location = new System.Drawing.Point(425, 444);
            this.btnAES.Name = "btnAES";
            this.btnAES.Size = new System.Drawing.Size(207, 177);
            this.btnAES.TabIndex = 4;
            this.btnAES.TabStop = false;
            this.btnAES.Click += new System.EventHandler(this.btnAES_Click);
            // 
            // btnDES
            // 
            this.btnDES.BackColor = System.Drawing.Color.Transparent;
            this.btnDES.BackgroundImage = global::Assignment1CAndNSecurity.Properties.Resources.btnDESNon;
            this.btnDES.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDES.Location = new System.Drawing.Point(491, 249);
            this.btnDES.Name = "btnDES";
            this.btnDES.Size = new System.Drawing.Size(207, 177);
            this.btnDES.TabIndex = 5;
            this.btnDES.TabStop = false;
            this.btnDES.Click += new System.EventHandler(this.btnDES_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.ControlBox = false;
            this.Controls.Add(this.btnDES);
            this.Controls.Add(this.btnAES);
            this.Controls.Add(this.btnDecryption);
            this.Controls.Add(this.btnEncryption);
            this.Controls.Add(this.btnExit);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment 1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEncryption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecryption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDES)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox btnEncryption;
        private System.Windows.Forms.PictureBox btnDecryption;
        private System.Windows.Forms.PictureBox btnAES;
        private System.Windows.Forms.PictureBox btnDES;
    }
}

