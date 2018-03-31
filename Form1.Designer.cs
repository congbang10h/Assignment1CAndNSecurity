namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.LbKey = new System.Windows.Forms.Label();
            this.LbOut = new System.Windows.Forms.Label();
            this.LbIn = new System.Windows.Forms.Label();
            this.LbMode = new System.Windows.Forms.Label();
            this.comboBoxKLen = new System.Windows.Forms.ComboBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOuput = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnOpenOut = new System.Windows.Forms.Button();
            this.btnOpFile = new System.Windows.Forms.Button();
            this.btnOpFolder = new System.Windows.Forms.Button();
            this.btnEn = new System.Windows.Forms.Button();
            this.btnDe = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // LbKey
            // 
            this.LbKey.AutoSize = true;
            this.LbKey.Location = new System.Drawing.Point(143, 56);
            this.LbKey.Name = "LbKey";
            this.LbKey.Size = new System.Drawing.Size(25, 13);
            this.LbKey.TabIndex = 0;
            this.LbKey.Text = "Key";
            // 
            // LbOut
            // 
            this.LbOut.AutoSize = true;
            this.LbOut.Location = new System.Drawing.Point(143, 184);
            this.LbOut.Name = "LbOut";
            this.LbOut.Size = new System.Drawing.Size(36, 13);
            this.LbOut.TabIndex = 1;
            this.LbOut.Text = "Ouput";
            // 
            // LbIn
            // 
            this.LbIn.AutoSize = true;
            this.LbIn.Location = new System.Drawing.Point(143, 100);
            this.LbIn.Name = "LbIn";
            this.LbIn.Size = new System.Drawing.Size(31, 13);
            this.LbIn.TabIndex = 2;
            this.LbIn.Text = "Input";
            // 
            // LbMode
            // 
            this.LbMode.AutoSize = true;
            this.LbMode.Location = new System.Drawing.Point(143, 143);
            this.LbMode.Name = "LbMode";
            this.LbMode.Size = new System.Drawing.Size(34, 13);
            this.LbMode.TabIndex = 3;
            this.LbMode.Text = "Mode";
            // 
            // comboBoxKLen
            // 
            this.comboBoxKLen.FormattingEnabled = true;
            this.comboBoxKLen.Items.AddRange(new object[] {
            "128bit",
            "192bit",
            "256bit"});
            this.comboBoxKLen.Location = new System.Drawing.Point(344, 53);
            this.comboBoxKLen.Name = "comboBoxKLen";
            this.comboBoxKLen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKLen.TabIndex = 4;
            this.comboBoxKLen.Text = "128bit";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "EBC",
            "CBC",
            "CBF"});
            this.comboBoxMode.Location = new System.Drawing.Point(209, 143);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(256, 21);
            this.comboBoxMode.TabIndex = 5;
            this.comboBoxMode.Text = "EBC";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(209, 54);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(119, 20);
            this.textBoxKey.TabIndex = 6;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(209, 97);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(256, 20);
            this.textBoxInput.TabIndex = 7;
            // 
            // textBoxOuput
            // 
            this.textBoxOuput.Location = new System.Drawing.Point(209, 181);
            this.textBoxOuput.Name = "textBoxOuput";
            this.textBoxOuput.Size = new System.Drawing.Size(256, 20);
            this.textBoxOuput.TabIndex = 8;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(504, 53);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnOpenOut
            // 
            this.btnOpenOut.Location = new System.Drawing.Point(504, 178);
            this.btnOpenOut.Name = "btnOpenOut";
            this.btnOpenOut.Size = new System.Drawing.Size(75, 23);
            this.btnOpenOut.TabIndex = 11;
            this.btnOpenOut.Text = "Open folder";
            this.btnOpenOut.UseVisualStyleBackColor = true;
            this.btnOpenOut.Click += new System.EventHandler(this.btnOpenOut_Click);
            // 
            // btnOpFile
            // 
            this.btnOpFile.Location = new System.Drawing.Point(504, 95);
            this.btnOpFile.Name = "btnOpFile";
            this.btnOpFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpFile.TabIndex = 12;
            this.btnOpFile.Text = "Open file";
            this.btnOpFile.UseVisualStyleBackColor = true;
            this.btnOpFile.Click += new System.EventHandler(this.btnOpFile_Click);
            // 
            // btnOpFolder
            // 
            this.btnOpFolder.Location = new System.Drawing.Point(598, 95);
            this.btnOpFolder.Name = "btnOpFolder";
            this.btnOpFolder.Size = new System.Drawing.Size(75, 23);
            this.btnOpFolder.TabIndex = 13;
            this.btnOpFolder.Text = "Open folder";
            this.btnOpFolder.UseVisualStyleBackColor = true;
            this.btnOpFolder.Click += new System.EventHandler(this.btnOpFolder_Click);
            // 
            // btnEn
            // 
            this.btnEn.Location = new System.Drawing.Point(209, 270);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(75, 23);
            this.btnEn.TabIndex = 14;
            this.btnEn.Text = "Encrypt";
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // btnDe
            // 
            this.btnDe.Location = new System.Drawing.Point(326, 270);
            this.btnDe.Name = "btnDe";
            this.btnDe.Size = new System.Drawing.Size(75, 23);
            this.btnDe.TabIndex = 15;
            this.btnDe.Text = "Decrypt";
            this.btnDe.UseVisualStyleBackColor = true;
            this.btnDe.Click += new System.EventHandler(this.btnDe_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(455, 270);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(209, 224);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(256, 23);
            this.progressBar1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 413);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDe);
            this.Controls.Add(this.btnEn);
            this.Controls.Add(this.btnOpFolder);
            this.Controls.Add(this.btnOpFile);
            this.Controls.Add(this.btnOpenOut);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.textBoxOuput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.comboBoxKLen);
            this.Controls.Add(this.LbMode);
            this.Controls.Add(this.LbIn);
            this.Controls.Add(this.LbOut);
            this.Controls.Add(this.LbKey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbKey;
        private System.Windows.Forms.Label LbOut;
        private System.Windows.Forms.Label LbIn;
        private System.Windows.Forms.Label LbMode;
        private System.Windows.Forms.ComboBox comboBoxKLen;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOuput;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnOpenOut;
        private System.Windows.Forms.Button btnOpFile;
        private System.Windows.Forms.Button btnOpFolder;
        private System.Windows.Forms.Button btnEn;
        private System.Windows.Forms.Button btnDe;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
    }
}

