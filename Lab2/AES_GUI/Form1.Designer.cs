namespace AES_GUI
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Encrypttab = new System.Windows.Forms.TabPage();
            this.Enc_Savebtn = new System.Windows.Forms.Button();
            this.Enc_Plainrtb = new System.Windows.Forms.RichTextBox();
            this.Enc_Cipherrtb = new System.Windows.Forms.RichTextBox();
            this.Enc_Keybtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Enc_Keytb = new System.Windows.Forms.TextBox();
            this.Enc_IVtb = new System.Windows.Forms.TextBox();
            this.Enc_Plaintextbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Enc_IVbtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Decrypttab = new System.Windows.Forms.TabPage();
            this.Dec_Savebtn = new System.Windows.Forms.Button();
            this.Dec_Plainrtb = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Dec_Ciphertextbtn = new System.Windows.Forms.Button();
            this.Dec_Cipherrtb = new System.Windows.Forms.RichTextBox();
            this.Ciphertext = new System.Windows.Forms.Label();
            this.Dec_IVbtn = new System.Windows.Forms.Button();
            this.Dec_IVtb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Dec_Keybtn = new System.Windows.Forms.Button();
            this.Dec_Keytb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Encryptbtn = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Encrypttab.SuspendLayout();
            this.Decrypttab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Encrypttab);
            this.tabControl1.Controls.Add(this.Decrypttab);
            this.tabControl1.Location = new System.Drawing.Point(17, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // Encrypttab
            // 
            this.Encrypttab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Encrypttab.Controls.Add(this.Encryptbtn);
            this.Encrypttab.Controls.Add(this.Enc_Savebtn);
            this.Encrypttab.Controls.Add(this.Enc_Plainrtb);
            this.Encrypttab.Controls.Add(this.Enc_Cipherrtb);
            this.Encrypttab.Controls.Add(this.Enc_Keybtn);
            this.Encrypttab.Controls.Add(this.label9);
            this.Encrypttab.Controls.Add(this.label7);
            this.Encrypttab.Controls.Add(this.Enc_Keytb);
            this.Encrypttab.Controls.Add(this.Enc_IVtb);
            this.Encrypttab.Controls.Add(this.Enc_Plaintextbtn);
            this.Encrypttab.Controls.Add(this.label10);
            this.Encrypttab.Controls.Add(this.Enc_IVbtn);
            this.Encrypttab.Controls.Add(this.label8);
            this.Encrypttab.Location = new System.Drawing.Point(4, 22);
            this.Encrypttab.Name = "Encrypttab";
            this.Encrypttab.Padding = new System.Windows.Forms.Padding(3);
            this.Encrypttab.Size = new System.Drawing.Size(568, 394);
            this.Encrypttab.TabIndex = 0;
            this.Encrypttab.Text = "Encrypt";
            // 
            // Enc_Savebtn
            // 
            this.Enc_Savebtn.Location = new System.Drawing.Point(400, 206);
            this.Enc_Savebtn.Name = "Enc_Savebtn";
            this.Enc_Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Enc_Savebtn.TabIndex = 11;
            this.Enc_Savebtn.Text = "Save to File";
            this.Enc_Savebtn.UseVisualStyleBackColor = true;
            this.Enc_Savebtn.Click += new System.EventHandler(this.Enc_Savebtn_Click);
            // 
            // Enc_Plainrtb
            // 
            this.Enc_Plainrtb.Location = new System.Drawing.Point(100, 82);
            this.Enc_Plainrtb.Name = "Enc_Plainrtb";
            this.Enc_Plainrtb.Size = new System.Drawing.Size(295, 108);
            this.Enc_Plainrtb.TabIndex = 7;
            this.Enc_Plainrtb.Text = "";
            // 
            // Enc_Cipherrtb
            // 
            this.Enc_Cipherrtb.Location = new System.Drawing.Point(99, 205);
            this.Enc_Cipherrtb.Name = "Enc_Cipherrtb";
            this.Enc_Cipherrtb.ReadOnly = true;
            this.Enc_Cipherrtb.Size = new System.Drawing.Size(295, 108);
            this.Enc_Cipherrtb.TabIndex = 10;
            this.Enc_Cipherrtb.Text = "";
            // 
            // Enc_Keybtn
            // 
            this.Enc_Keybtn.Location = new System.Drawing.Point(401, 15);
            this.Enc_Keybtn.Name = "Enc_Keybtn";
            this.Enc_Keybtn.Size = new System.Drawing.Size(75, 23);
            this.Enc_Keybtn.TabIndex = 2;
            this.Enc_Keybtn.Text = "Browse";
            this.Enc_Keybtn.UseVisualStyleBackColor = true;
            this.Enc_Keybtn.Click += new System.EventHandler(this.Enc_Keybtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(68, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 21);
            this.label9.TabIndex = 3;
            this.label9.Text = "IV:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ciphertext:";
            // 
            // Enc_Keytb
            // 
            this.Enc_Keytb.Location = new System.Drawing.Point(101, 15);
            this.Enc_Keytb.Name = "Enc_Keytb";
            this.Enc_Keytb.Size = new System.Drawing.Size(294, 20);
            this.Enc_Keytb.TabIndex = 1;
            // 
            // Enc_IVtb
            // 
            this.Enc_IVtb.Location = new System.Drawing.Point(100, 46);
            this.Enc_IVtb.Name = "Enc_IVtb";
            this.Enc_IVtb.Size = new System.Drawing.Size(294, 20);
            this.Enc_IVtb.TabIndex = 4;
            // 
            // Enc_Plaintextbtn
            // 
            this.Enc_Plaintextbtn.Location = new System.Drawing.Point(400, 82);
            this.Enc_Plaintextbtn.Name = "Enc_Plaintextbtn";
            this.Enc_Plaintextbtn.Size = new System.Drawing.Size(75, 23);
            this.Enc_Plaintextbtn.TabIndex = 8;
            this.Enc_Plaintextbtn.Text = "Browse";
            this.Enc_Plaintextbtn.UseVisualStyleBackColor = true;
            this.Enc_Plaintextbtn.Click += new System.EventHandler(this.Enc_Plaintextbtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(57, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "Key:";
            // 
            // Enc_IVbtn
            // 
            this.Enc_IVbtn.Location = new System.Drawing.Point(400, 46);
            this.Enc_IVbtn.Name = "Enc_IVbtn";
            this.Enc_IVbtn.Size = new System.Drawing.Size(75, 23);
            this.Enc_IVbtn.TabIndex = 5;
            this.Enc_IVbtn.Text = "Browse";
            this.Enc_IVbtn.UseVisualStyleBackColor = true;
            this.Enc_IVbtn.Click += new System.EventHandler(this.Enc_IVbtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Plaintext:";
            // 
            // Decrypttab
            // 
            this.Decrypttab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Decrypttab.Controls.Add(this.Decrypt);
            this.Decrypttab.Controls.Add(this.Dec_Savebtn);
            this.Decrypttab.Controls.Add(this.Dec_Plainrtb);
            this.Decrypttab.Controls.Add(this.label6);
            this.Decrypttab.Controls.Add(this.Dec_Ciphertextbtn);
            this.Decrypttab.Controls.Add(this.Dec_Cipherrtb);
            this.Decrypttab.Controls.Add(this.Ciphertext);
            this.Decrypttab.Controls.Add(this.Dec_IVbtn);
            this.Decrypttab.Controls.Add(this.Dec_IVtb);
            this.Decrypttab.Controls.Add(this.label5);
            this.Decrypttab.Controls.Add(this.Dec_Keybtn);
            this.Decrypttab.Controls.Add(this.Dec_Keytb);
            this.Decrypttab.Controls.Add(this.label4);
            this.Decrypttab.Location = new System.Drawing.Point(4, 22);
            this.Decrypttab.Name = "Decrypttab";
            this.Decrypttab.Padding = new System.Windows.Forms.Padding(3);
            this.Decrypttab.Size = new System.Drawing.Size(568, 394);
            this.Decrypttab.TabIndex = 1;
            this.Decrypttab.Text = "Decrypt";
            // 
            // Dec_Savebtn
            // 
            this.Dec_Savebtn.Location = new System.Drawing.Point(401, 206);
            this.Dec_Savebtn.Name = "Dec_Savebtn";
            this.Dec_Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Dec_Savebtn.TabIndex = 11;
            this.Dec_Savebtn.Text = "Save to File";
            this.Dec_Savebtn.UseVisualStyleBackColor = true;
            this.Dec_Savebtn.Click += new System.EventHandler(this.Dec_Savebtn_Click);
            // 
            // Dec_Plainrtb
            // 
            this.Dec_Plainrtb.Location = new System.Drawing.Point(100, 205);
            this.Dec_Plainrtb.Name = "Dec_Plainrtb";
            this.Dec_Plainrtb.ReadOnly = true;
            this.Dec_Plainrtb.Size = new System.Drawing.Size(295, 108);
            this.Dec_Plainrtb.TabIndex = 10;
            this.Dec_Plainrtb.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Plaintext:";
            // 
            // Dec_Ciphertextbtn
            // 
            this.Dec_Ciphertextbtn.Location = new System.Drawing.Point(401, 82);
            this.Dec_Ciphertextbtn.Name = "Dec_Ciphertextbtn";
            this.Dec_Ciphertextbtn.Size = new System.Drawing.Size(75, 23);
            this.Dec_Ciphertextbtn.TabIndex = 8;
            this.Dec_Ciphertextbtn.Text = "Browse";
            this.Dec_Ciphertextbtn.UseVisualStyleBackColor = true;
            this.Dec_Ciphertextbtn.Click += new System.EventHandler(this.Dec_Ciphertextbtn_Click);
            // 
            // Dec_Cipherrtb
            // 
            this.Dec_Cipherrtb.Location = new System.Drawing.Point(101, 82);
            this.Dec_Cipherrtb.Name = "Dec_Cipherrtb";
            this.Dec_Cipherrtb.Size = new System.Drawing.Size(295, 108);
            this.Dec_Cipherrtb.TabIndex = 7;
            this.Dec_Cipherrtb.Text = "";
            // 
            // Ciphertext
            // 
            this.Ciphertext.AutoSize = true;
            this.Ciphertext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ciphertext.Location = new System.Drawing.Point(12, 79);
            this.Ciphertext.Name = "Ciphertext";
            this.Ciphertext.Size = new System.Drawing.Size(84, 21);
            this.Ciphertext.TabIndex = 6;
            this.Ciphertext.Text = "Ciphertext:";
            // 
            // Dec_IVbtn
            // 
            this.Dec_IVbtn.Location = new System.Drawing.Point(401, 46);
            this.Dec_IVbtn.Name = "Dec_IVbtn";
            this.Dec_IVbtn.Size = new System.Drawing.Size(75, 23);
            this.Dec_IVbtn.TabIndex = 5;
            this.Dec_IVbtn.Text = "Browse";
            this.Dec_IVbtn.UseVisualStyleBackColor = true;
            this.Dec_IVbtn.Click += new System.EventHandler(this.Dec_IVbtn_Click);
            // 
            // Dec_IVtb
            // 
            this.Dec_IVtb.Location = new System.Drawing.Point(101, 46);
            this.Dec_IVtb.Name = "Dec_IVtb";
            this.Dec_IVtb.Size = new System.Drawing.Size(294, 20);
            this.Dec_IVtb.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "IV:";
            // 
            // Dec_Keybtn
            // 
            this.Dec_Keybtn.Location = new System.Drawing.Point(402, 15);
            this.Dec_Keybtn.Name = "Dec_Keybtn";
            this.Dec_Keybtn.Size = new System.Drawing.Size(75, 23);
            this.Dec_Keybtn.TabIndex = 2;
            this.Dec_Keybtn.Text = "Browse";
            this.Dec_Keybtn.UseVisualStyleBackColor = true;
            this.Dec_Keybtn.Click += new System.EventHandler(this.Dec_Keybtn_Click);
            // 
            // Dec_Keytb
            // 
            this.Dec_Keytb.Location = new System.Drawing.Point(102, 15);
            this.Dec_Keytb.Name = "Dec_Keytb";
            this.Dec_Keytb.Size = new System.Drawing.Size(294, 20);
            this.Dec_Keytb.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task 2: AES - CBC mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "23520669 - Phạm Lê Đăng Kha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 537);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "NT219.P21.ANTT";
            // 
            // Encryptbtn
            // 
            this.Encryptbtn.Location = new System.Drawing.Point(192, 332);
            this.Encryptbtn.Name = "Encryptbtn";
            this.Encryptbtn.Size = new System.Drawing.Size(91, 44);
            this.Encryptbtn.TabIndex = 12;
            this.Encryptbtn.Text = "Encrypt";
            this.Encryptbtn.UseVisualStyleBackColor = true;
            this.Encryptbtn.Click += new System.EventHandler(this.Encryptbtn_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(187, 332);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(91, 44);
            this.Decrypt.TabIndex = 13;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 576);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Task 2";
            this.tabControl1.ResumeLayout(false);
            this.Encrypttab.ResumeLayout(false);
            this.Encrypttab.PerformLayout();
            this.Decrypttab.ResumeLayout(false);
            this.Decrypttab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Encrypttab;
        private System.Windows.Forms.TabPage Decrypttab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Dec_Keybtn;
        private System.Windows.Forms.TextBox Dec_Keytb;
        private System.Windows.Forms.TextBox Dec_IVtb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Enc_Savebtn;
        private System.Windows.Forms.RichTextBox Enc_Plainrtb;
        private System.Windows.Forms.RichTextBox Enc_Cipherrtb;
        private System.Windows.Forms.Button Enc_Keybtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Enc_Keytb;
        private System.Windows.Forms.TextBox Enc_IVtb;
        private System.Windows.Forms.Button Enc_Plaintextbtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Enc_IVbtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Dec_Savebtn;
        private System.Windows.Forms.RichTextBox Dec_Plainrtb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Dec_Ciphertextbtn;
        private System.Windows.Forms.RichTextBox Dec_Cipherrtb;
        private System.Windows.Forms.Label Ciphertext;
        private System.Windows.Forms.Button Dec_IVbtn;
        private System.Windows.Forms.Button Encryptbtn;
        private System.Windows.Forms.Button Decrypt;
    }
}

