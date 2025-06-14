namespace AES_GUI
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
            this.AESModecb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Formatcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyFiletb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IVFiletb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Ciphertextrtb = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ciphercb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Plaintextrtb = new System.Windows.Forms.RichTextBox();
            this.KeyFilebtn = new System.Windows.Forms.Button();
            this.IVFilebtn = new System.Windows.Forms.Button();
            this.Decryptbtn = new System.Windows.Forms.Button();
            this.Ciphertextbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mode:";
            // 
            // AESModecb
            // 
            this.AESModecb.FormattingEnabled = true;
            this.AESModecb.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "CFB",
            "OFB",
            "CTR",
            "XTS",
            "CCM",
            "GCM"});
            this.AESModecb.Location = new System.Drawing.Point(169, 21);
            this.AESModecb.Name = "AESModecb";
            this.AESModecb.Size = new System.Drawing.Size(121, 21);
            this.AESModecb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Key Format:";
            // 
            // Formatcb
            // 
            this.Formatcb.FormattingEnabled = true;
            this.Formatcb.Items.AddRange(new object[] {
            "Binary",
            "Hex",
            "Base64"});
            this.Formatcb.Location = new System.Drawing.Point(169, 56);
            this.Formatcb.Name = "Formatcb";
            this.Formatcb.Size = new System.Drawing.Size(121, 21);
            this.Formatcb.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Key File:";
            // 
            // KeyFiletb
            // 
            this.KeyFiletb.Location = new System.Drawing.Point(169, 96);
            this.KeyFiletb.Name = "KeyFiletb";
            this.KeyFiletb.Size = new System.Drawing.Size(215, 20);
            this.KeyFiletb.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "IV File:";
            // 
            // IVFiletb
            // 
            this.IVFiletb.Location = new System.Drawing.Point(169, 140);
            this.IVFiletb.Name = "IVFiletb";
            this.IVFiletb.Size = new System.Drawing.Size(215, 20);
            this.IVFiletb.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ciphertext:";
            // 
            // Ciphertextrtb
            // 
            this.Ciphertextrtb.Location = new System.Drawing.Point(169, 218);
            this.Ciphertextrtb.Name = "Ciphertextrtb";
            this.Ciphertextrtb.Size = new System.Drawing.Size(215, 96);
            this.Ciphertextrtb.TabIndex = 22;
            this.Ciphertextrtb.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Cipher Format:";
            // 
            // Ciphercb
            // 
            this.Ciphercb.FormattingEnabled = true;
            this.Ciphercb.Items.AddRange(new object[] {
            "Hex",
            "Base64"});
            this.Ciphercb.Location = new System.Drawing.Point(169, 177);
            this.Ciphercb.Name = "Ciphercb";
            this.Ciphercb.Size = new System.Drawing.Size(121, 21);
            this.Ciphercb.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(86, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 25;
            this.label6.Text = "Plaintext:";
            // 
            // Plaintextrtb
            // 
            this.Plaintextrtb.Location = new System.Drawing.Point(169, 343);
            this.Plaintextrtb.Name = "Plaintextrtb";
            this.Plaintextrtb.ReadOnly = true;
            this.Plaintextrtb.Size = new System.Drawing.Size(215, 96);
            this.Plaintextrtb.TabIndex = 26;
            this.Plaintextrtb.Text = "";
            // 
            // KeyFilebtn
            // 
            this.KeyFilebtn.Location = new System.Drawing.Point(390, 96);
            this.KeyFilebtn.Name = "KeyFilebtn";
            this.KeyFilebtn.Size = new System.Drawing.Size(75, 23);
            this.KeyFilebtn.TabIndex = 27;
            this.KeyFilebtn.Text = "Browse";
            this.KeyFilebtn.UseVisualStyleBackColor = true;
            this.KeyFilebtn.Click += new System.EventHandler(this.KeyFilebtn_Click);
            // 
            // IVFilebtn
            // 
            this.IVFilebtn.Location = new System.Drawing.Point(390, 138);
            this.IVFilebtn.Name = "IVFilebtn";
            this.IVFilebtn.Size = new System.Drawing.Size(75, 23);
            this.IVFilebtn.TabIndex = 28;
            this.IVFilebtn.Text = "Browse";
            this.IVFilebtn.UseVisualStyleBackColor = true;
            this.IVFilebtn.Click += new System.EventHandler(this.IVFilebtn_Click);
            // 
            // Decryptbtn
            // 
            this.Decryptbtn.Location = new System.Drawing.Point(214, 461);
            this.Decryptbtn.Name = "Decryptbtn";
            this.Decryptbtn.Size = new System.Drawing.Size(99, 38);
            this.Decryptbtn.TabIndex = 29;
            this.Decryptbtn.Text = "Decrypt";
            this.Decryptbtn.UseVisualStyleBackColor = true;
            this.Decryptbtn.Click += new System.EventHandler(this.Decryptbtn_Click);
            // 
            // Ciphertextbtn
            // 
            this.Ciphertextbtn.Location = new System.Drawing.Point(390, 216);
            this.Ciphertextbtn.Name = "Ciphertextbtn";
            this.Ciphertextbtn.Size = new System.Drawing.Size(75, 23);
            this.Ciphertextbtn.TabIndex = 30;
            this.Ciphertextbtn.Text = "Browse";
            this.Ciphertextbtn.UseVisualStyleBackColor = true;
            this.Ciphertextbtn.Click += new System.EventHandler(this.Ciphertextbtn_Click);
            // 
            // Decrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 526);
            this.Controls.Add(this.Ciphertextbtn);
            this.Controls.Add(this.Decryptbtn);
            this.Controls.Add(this.IVFilebtn);
            this.Controls.Add(this.KeyFilebtn);
            this.Controls.Add(this.Plaintextrtb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Ciphercb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ciphertextrtb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.IVFiletb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.KeyFiletb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Formatcb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AESModecb);
            this.Controls.Add(this.label1);
            this.Name = "Decrypt";
            this.Text = "Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AESModecb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Formatcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KeyFiletb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IVFiletb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox Ciphertextrtb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Ciphercb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Plaintextrtb;
        private System.Windows.Forms.Button KeyFilebtn;
        private System.Windows.Forms.Button IVFilebtn;
        private System.Windows.Forms.Button Decryptbtn;
        private System.Windows.Forms.Button Ciphertextbtn;
    }
}