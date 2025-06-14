namespace AES_GUI
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
            this.AESModecb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Formatcb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KeyFiletb = new System.Windows.Forms.TextBox();
            this.IVFiletb = new System.Windows.Forms.TextBox();
            this.KeyFilebtn = new System.Windows.Forms.Button();
            this.IVFilebtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Ciphercb = new System.Windows.Forms.ComboBox();
            this.Plaintextrtb = new System.Windows.Forms.RichTextBox();
            this.Cipherrtb = new System.Windows.Forms.RichTextBox();
            this.Plaintextbtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Encryptbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.AESModecb.Location = new System.Drawing.Point(170, 32);
            this.AESModecb.Name = "AESModecb";
            this.AESModecb.Size = new System.Drawing.Size(121, 21);
            this.AESModecb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mode:";
            // 
            // Formatcb
            // 
            this.Formatcb.FormattingEnabled = true;
            this.Formatcb.Items.AddRange(new object[] {
            "Binary",
            "Hex",
            "Base64"});
            this.Formatcb.Location = new System.Drawing.Point(170, 66);
            this.Formatcb.Name = "Formatcb";
            this.Formatcb.Size = new System.Drawing.Size(121, 21);
            this.Formatcb.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Key Format:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Key File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(106, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 12;
            this.label5.Text = "IV File:";
            // 
            // KeyFiletb
            // 
            this.KeyFiletb.Location = new System.Drawing.Point(170, 102);
            this.KeyFiletb.Name = "KeyFiletb";
            this.KeyFiletb.Size = new System.Drawing.Size(215, 20);
            this.KeyFiletb.TabIndex = 13;
            // 
            // IVFiletb
            // 
            this.IVFiletb.Location = new System.Drawing.Point(170, 142);
            this.IVFiletb.Name = "IVFiletb";
            this.IVFiletb.Size = new System.Drawing.Size(215, 20);
            this.IVFiletb.TabIndex = 14;
            // 
            // KeyFilebtn
            // 
            this.KeyFilebtn.Location = new System.Drawing.Point(391, 99);
            this.KeyFilebtn.Name = "KeyFilebtn";
            this.KeyFilebtn.Size = new System.Drawing.Size(75, 23);
            this.KeyFilebtn.TabIndex = 15;
            this.KeyFilebtn.Text = "Browse";
            this.KeyFilebtn.UseVisualStyleBackColor = true;
            this.KeyFilebtn.Click += new System.EventHandler(this.KeyFilebtn_Click);
            // 
            // IVFilebtn
            // 
            this.IVFilebtn.Location = new System.Drawing.Point(391, 142);
            this.IVFilebtn.Name = "IVFilebtn";
            this.IVFilebtn.Size = new System.Drawing.Size(75, 23);
            this.IVFilebtn.TabIndex = 16;
            this.IVFilebtn.Text = "Browse";
            this.IVFilebtn.UseVisualStyleBackColor = true;
            this.IVFilebtn.Click += new System.EventHandler(this.IVFilebtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cipher Format:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "Plaintext:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Ciphertext:";
            // 
            // Ciphercb
            // 
            this.Ciphercb.FormattingEnabled = true;
            this.Ciphercb.Items.AddRange(new object[] {
            "Hex",
            "Base64"});
            this.Ciphercb.Location = new System.Drawing.Point(170, 309);
            this.Ciphercb.Name = "Ciphercb";
            this.Ciphercb.Size = new System.Drawing.Size(121, 21);
            this.Ciphercb.TabIndex = 20;
            // 
            // Plaintextrtb
            // 
            this.Plaintextrtb.Location = new System.Drawing.Point(170, 189);
            this.Plaintextrtb.Name = "Plaintextrtb";
            this.Plaintextrtb.Size = new System.Drawing.Size(215, 96);
            this.Plaintextrtb.TabIndex = 21;
            this.Plaintextrtb.Text = "";
            // 
            // Cipherrtb
            // 
            this.Cipherrtb.Location = new System.Drawing.Point(170, 350);
            this.Cipherrtb.Name = "Cipherrtb";
            this.Cipherrtb.ReadOnly = true;
            this.Cipherrtb.Size = new System.Drawing.Size(215, 96);
            this.Cipherrtb.TabIndex = 22;
            this.Cipherrtb.Text = "";
            // 
            // Plaintextbtn
            // 
            this.Plaintextbtn.Location = new System.Drawing.Point(391, 189);
            this.Plaintextbtn.Name = "Plaintextbtn";
            this.Plaintextbtn.Size = new System.Drawing.Size(75, 23);
            this.Plaintextbtn.TabIndex = 23;
            this.Plaintextbtn.Text = "Browse";
            this.Plaintextbtn.UseVisualStyleBackColor = true;
            this.Plaintextbtn.Click += new System.EventHandler(this.Plaintextbtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(391, 350);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Savebtn.TabIndex = 24;
            this.Savebtn.Text = "Save to file";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Encryptbtn
            // 
            this.Encryptbtn.Location = new System.Drawing.Point(215, 463);
            this.Encryptbtn.Name = "Encryptbtn";
            this.Encryptbtn.Size = new System.Drawing.Size(99, 38);
            this.Encryptbtn.TabIndex = 25;
            this.Encryptbtn.Text = "Encrypt";
            this.Encryptbtn.UseVisualStyleBackColor = true;
            this.Encryptbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Encrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 536);
            this.Controls.Add(this.Encryptbtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.Plaintextbtn);
            this.Controls.Add(this.Cipherrtb);
            this.Controls.Add(this.Plaintextrtb);
            this.Controls.Add(this.Ciphercb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IVFilebtn);
            this.Controls.Add(this.KeyFilebtn);
            this.Controls.Add(this.IVFiletb);
            this.Controls.Add(this.KeyFiletb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Formatcb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AESModecb);
            this.Name = "Encrypt";
            this.Text = "Encrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AESModecb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Formatcb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KeyFiletb;
        private System.Windows.Forms.TextBox IVFiletb;
        private System.Windows.Forms.Button KeyFilebtn;
        private System.Windows.Forms.Button IVFilebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Ciphercb;
        private System.Windows.Forms.RichTextBox Plaintextrtb;
        private System.Windows.Forms.RichTextBox Cipherrtb;
        private System.Windows.Forms.Button Plaintextbtn;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Encryptbtn;
    }
}