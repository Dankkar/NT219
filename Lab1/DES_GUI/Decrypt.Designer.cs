namespace DES_GUI
{
    partial class Decrypt
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
            this.label7 = new System.Windows.Forms.Label();
            this.Ciphertextrtb = new System.Windows.Forms.RichTextBox();
            this.Ciphercb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Plaintextrtb = new System.Windows.Forms.RichTextBox();
            this.SaveFilebtn = new System.Windows.Forms.Button();
            this.Ciphertextbtn = new System.Windows.Forms.Button();
            this.BrowseIVbtn = new System.Windows.Forms.Button();
            this.BrowseKeybtn = new System.Windows.Forms.Button();
            this.Decryptbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 2;
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
            this.DESModecb.Location = new System.Drawing.Point(147, 22);
            this.DESModecb.Name = "DESModecb";
            this.DESModecb.Size = new System.Drawing.Size(189, 21);
            this.DESModecb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key Format:";
            // 
            // Formatcb
            // 
            this.Formatcb.FormattingEnabled = true;
            this.Formatcb.Items.AddRange(new object[] {
            "Binary",
            "Hex",
            "Base64"});
            this.Formatcb.Location = new System.Drawing.Point(147, 58);
            this.Formatcb.Name = "Formatcb";
            this.Formatcb.Size = new System.Drawing.Size(189, 21);
            this.Formatcb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Key File:";
            // 
            // KeyFiletb
            // 
            this.KeyFiletb.Location = new System.Drawing.Point(147, 96);
            this.KeyFiletb.Name = "KeyFiletb";
            this.KeyFiletb.Size = new System.Drawing.Size(270, 20);
            this.KeyFiletb.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "IV File:";
            // 
            // IVFiletb
            // 
            this.IVFiletb.Location = new System.Drawing.Point(147, 138);
            this.IVFiletb.Name = "IVFiletb";
            this.IVFiletb.Size = new System.Drawing.Size(270, 20);
            this.IVFiletb.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ciphertext:";
            // 
            // Ciphertextrtb
            // 
            this.Ciphertextrtb.Location = new System.Drawing.Point(147, 185);
            this.Ciphertextrtb.Name = "Ciphertextrtb";
            this.Ciphertextrtb.Size = new System.Drawing.Size(189, 105);
            this.Ciphertextrtb.TabIndex = 22;
            this.Ciphertextrtb.Text = "";
            // 
            // Ciphercb
            // 
            this.Ciphercb.FormattingEnabled = true;
            this.Ciphercb.Items.AddRange(new object[] {
            "Hex",
            "Base64"});
            this.Ciphercb.Location = new System.Drawing.Point(147, 311);
            this.Ciphercb.Name = "Ciphercb";
            this.Ciphercb.Size = new System.Drawing.Size(189, 21);
            this.Ciphercb.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Cipher Format:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Plaintext:";
            // 
            // Plaintextrtb
            // 
            this.Plaintextrtb.Location = new System.Drawing.Point(147, 363);
            this.Plaintextrtb.Name = "Plaintextrtb";
            this.Plaintextrtb.ReadOnly = true;
            this.Plaintextrtb.Size = new System.Drawing.Size(189, 105);
            this.Plaintextrtb.TabIndex = 26;
            this.Plaintextrtb.Text = "";
            // 
            // SaveFilebtn
            // 
            this.SaveFilebtn.Location = new System.Drawing.Point(342, 363);
            this.SaveFilebtn.Name = "SaveFilebtn";
            this.SaveFilebtn.Size = new System.Drawing.Size(75, 23);
            this.SaveFilebtn.TabIndex = 30;
            this.SaveFilebtn.Text = "Save to file";
            this.SaveFilebtn.UseVisualStyleBackColor = true;
            this.SaveFilebtn.Click += new System.EventHandler(this.SaveFilebtn_Click);
            // 
            // Ciphertextbtn
            // 
            this.Ciphertextbtn.Location = new System.Drawing.Point(342, 185);
            this.Ciphertextbtn.Name = "Ciphertextbtn";
            this.Ciphertextbtn.Size = new System.Drawing.Size(75, 23);
            this.Ciphertextbtn.TabIndex = 29;
            this.Ciphertextbtn.Text = "Browse";
            this.Ciphertextbtn.UseVisualStyleBackColor = true;
            this.Ciphertextbtn.Click += new System.EventHandler(this.Ciphertextbtn_Click);
            // 
            // BrowseIVbtn
            // 
            this.BrowseIVbtn.Location = new System.Drawing.Point(423, 138);
            this.BrowseIVbtn.Name = "BrowseIVbtn";
            this.BrowseIVbtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseIVbtn.TabIndex = 28;
            this.BrowseIVbtn.Text = "Browse";
            this.BrowseIVbtn.UseVisualStyleBackColor = true;
            this.BrowseIVbtn.Click += new System.EventHandler(this.BrowseIVbtn_Click);
            // 
            // BrowseKeybtn
            // 
            this.BrowseKeybtn.Location = new System.Drawing.Point(423, 96);
            this.BrowseKeybtn.Name = "BrowseKeybtn";
            this.BrowseKeybtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseKeybtn.TabIndex = 27;
            this.BrowseKeybtn.Text = "Browse";
            this.BrowseKeybtn.UseVisualStyleBackColor = true;
            this.BrowseKeybtn.Click += new System.EventHandler(this.BrowseKeybtn_Click);
            // 
            // Decryptbtn
            // 
            this.Decryptbtn.Location = new System.Drawing.Point(195, 486);
            this.Decryptbtn.Name = "Decryptbtn";
            this.Decryptbtn.Size = new System.Drawing.Size(93, 44);
            this.Decryptbtn.TabIndex = 31;
            this.Decryptbtn.Text = "Decrypt";
            this.Decryptbtn.UseVisualStyleBackColor = true;
            this.Decryptbtn.Click += new System.EventHandler(this.Decryptbtn_Click);
            // 
            // Decrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 577);
            this.Controls.Add(this.Decryptbtn);
            this.Controls.Add(this.SaveFilebtn);
            this.Controls.Add(this.Ciphertextbtn);
            this.Controls.Add(this.BrowseIVbtn);
            this.Controls.Add(this.BrowseKeybtn);
            this.Controls.Add(this.Plaintextrtb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ciphercb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Ciphertextrtb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.IVFiletb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KeyFiletb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Formatcb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DESModecb);
            this.Controls.Add(this.label1);
            this.Name = "Decrypt";
            this.Text = "Decrypt";
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox Ciphertextrtb;
        private System.Windows.Forms.ComboBox Ciphercb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox Plaintextrtb;
        private System.Windows.Forms.Button SaveFilebtn;
        private System.Windows.Forms.Button Ciphertextbtn;
        private System.Windows.Forms.Button BrowseIVbtn;
        private System.Windows.Forms.Button BrowseKeybtn;
        private System.Windows.Forms.Button Decryptbtn;
    }
}