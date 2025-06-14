namespace DES_GUI
{
    partial class Encrypt
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
            this.label1 = new System.Windows.Forms.Label();
            this.DESModecb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Formatcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyFiletb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IVFiletb = new System.Windows.Forms.TextBox();
            this.BrowseKeybtn = new System.Windows.Forms.Button();
            this.BrowseIVbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Plaintextrtb = new System.Windows.Forms.RichTextBox();
            this.Plaintextbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Cipherrtb = new System.Windows.Forms.RichTextBox();
            this.Ciphercb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SaveFilebtn = new System.Windows.Forms.Button();
            this.Encryptbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mode:";
            // 
            // DESModecb
            // 
            this.DESModecb.FormattingEnabled = true;
            this.DESModecb.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "CFB",
            "OFB",
            "CTR"});
            this.DESModecb.Location = new System.Drawing.Point(156, 24);
            this.DESModecb.Name = "DESModecb";
            this.DESModecb.Size = new System.Drawing.Size(189, 21);
            this.DESModecb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Key Format:";
            // 
            // Formatcb
            // 
            this.Formatcb.FormattingEnabled = true;
            this.Formatcb.Items.AddRange(new object[] {
            "Binary",
            "Hex",
            "Base64"});
            this.Formatcb.Location = new System.Drawing.Point(156, 57);
            this.Formatcb.Name = "Formatcb";
            this.Formatcb.Size = new System.Drawing.Size(189, 21);
            this.Formatcb.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Key File:";
            // 
            // KeyFiletb
            // 
            this.KeyFiletb.Location = new System.Drawing.Point(156, 96);
            this.KeyFiletb.Name = "KeyFiletb";
            this.KeyFiletb.Size = new System.Drawing.Size(254, 20);
            this.KeyFiletb.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(82, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "IV File:";
            // 
            // IVFiletb
            // 
            this.IVFiletb.Location = new System.Drawing.Point(156, 130);
            this.IVFiletb.Name = "IVFiletb";
            this.IVFiletb.Size = new System.Drawing.Size(254, 20);
            this.IVFiletb.TabIndex = 11;
            // 
            // BrowseKeybtn
            // 
            this.BrowseKeybtn.Location = new System.Drawing.Point(416, 94);
            this.BrowseKeybtn.Name = "BrowseKeybtn";
            this.BrowseKeybtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseKeybtn.TabIndex = 12;
            this.BrowseKeybtn.Text = "Browse";
            this.BrowseKeybtn.UseVisualStyleBackColor = true;
            this.BrowseKeybtn.Click += new System.EventHandler(this.BrowseKeybtn_Click);
            // 
            // BrowseIVbtn
            // 
            this.BrowseIVbtn.Location = new System.Drawing.Point(416, 129);
            this.BrowseIVbtn.Name = "BrowseIVbtn";
            this.BrowseIVbtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseIVbtn.TabIndex = 13;
            this.BrowseIVbtn.Text = "Browse";
            this.BrowseIVbtn.UseVisualStyleBackColor = true;
            this.BrowseIVbtn.Click += new System.EventHandler(this.BrowseIVbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Plaintext:";
            // 
            // Plaintextrtb
            // 
            this.Plaintextrtb.Location = new System.Drawing.Point(156, 165);
            this.Plaintextrtb.Name = "Plaintextrtb";
            this.Plaintextrtb.Size = new System.Drawing.Size(189, 105);
            this.Plaintextrtb.TabIndex = 15;
            this.Plaintextrtb.Text = "";
            // 
            // Plaintextbtn
            // 
            this.Plaintextbtn.Location = new System.Drawing.Point(351, 165);
            this.Plaintextbtn.Name = "Plaintextbtn";
            this.Plaintextbtn.Size = new System.Drawing.Size(75, 23);
            this.Plaintextbtn.TabIndex = 16;
            this.Plaintextbtn.Text = "Browse";
            this.Plaintextbtn.UseVisualStyleBackColor = true;
            this.Plaintextbtn.Click += new System.EventHandler(this.Plaintextbtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Cipher Format:";
            // 
            // Cipherrtb
            // 
            this.Cipherrtb.Location = new System.Drawing.Point(156, 329);
            this.Cipherrtb.Name = "Cipherrtb";
            this.Cipherrtb.ReadOnly = true;
            this.Cipherrtb.Size = new System.Drawing.Size(189, 105);
            this.Cipherrtb.TabIndex = 18;
            this.Cipherrtb.Text = "";
            // 
            // Ciphercb
            // 
            this.Ciphercb.FormattingEnabled = true;
            this.Ciphercb.Items.AddRange(new object[] {
            "Hex",
            "Base64"});
            this.Ciphercb.Location = new System.Drawing.Point(156, 290);
            this.Ciphercb.Name = "Ciphercb";
            this.Ciphercb.Size = new System.Drawing.Size(189, 21);
            this.Ciphercb.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ciphertext:";
            // 
            // SaveFilebtn
            // 
            this.SaveFilebtn.Location = new System.Drawing.Point(351, 330);
            this.SaveFilebtn.Name = "SaveFilebtn";
            this.SaveFilebtn.Size = new System.Drawing.Size(75, 23);
            this.SaveFilebtn.TabIndex = 21;
            this.SaveFilebtn.Text = "Save to file";
            this.SaveFilebtn.UseVisualStyleBackColor = true;
            this.SaveFilebtn.Click += new System.EventHandler(this.SaveFilebtn_Click);
            // 
            // Encryptbtn
            // 
            this.Encryptbtn.Location = new System.Drawing.Point(201, 440);
            this.Encryptbtn.Name = "Encryptbtn";
            this.Encryptbtn.Size = new System.Drawing.Size(93, 44);
            this.Encryptbtn.TabIndex = 22;
            this.Encryptbtn.Text = "Encrypt";
            this.Encryptbtn.UseVisualStyleBackColor = true;
            this.Encryptbtn.Click += new System.EventHandler(this.Encryptbtn_Click);
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 531);
            this.Controls.Add(this.Encryptbtn);
            this.Controls.Add(this.SaveFilebtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Ciphercb);
            this.Controls.Add(this.Cipherrtb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Plaintextbtn);
            this.Controls.Add(this.Plaintextrtb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseIVbtn);
            this.Controls.Add(this.BrowseKeybtn);
            this.Controls.Add(this.IVFiletb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KeyFiletb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Formatcb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DESModecb);
            this.Controls.Add(this.label1);
            this.Name = "Encrypt";
            this.Text = "Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DESModecb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Formatcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KeyFiletb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IVFiletb;
        private System.Windows.Forms.Button BrowseKeybtn;
        private System.Windows.Forms.Button BrowseIVbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox Plaintextrtb;
        private System.Windows.Forms.Button Plaintextbtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Cipherrtb;
        private System.Windows.Forms.ComboBox Ciphercb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SaveFilebtn;
        private System.Windows.Forms.Button Encryptbtn;
    }
}