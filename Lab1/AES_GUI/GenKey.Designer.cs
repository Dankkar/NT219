namespace AES_GUI
{
    partial class GenKey
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
            this.label2 = new System.Windows.Forms.Label();
            this.KeySizetb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Formatcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.KeyFiletb = new System.Windows.Forms.TextBox();
            this.KeyFilebtn = new System.Windows.Forms.Button();
            this.Generatebtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.IVFiletb = new System.Windows.Forms.TextBox();
            this.IVFilebtn = new System.Windows.Forms.Button();
            this.Genbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 1;
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
            this.AESModecb.Location = new System.Drawing.Point(152, 24);
            this.AESModecb.Name = "AESModecb";
            this.AESModecb.Size = new System.Drawing.Size(121, 21);
            this.AESModecb.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Key Size:";
            // 
            // KeySizetb
            // 
            this.KeySizetb.Location = new System.Drawing.Point(153, 60);
            this.KeySizetb.Name = "KeySizetb";
            this.KeySizetb.Size = new System.Drawing.Size(216, 20);
            this.KeySizetb.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
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
            this.Formatcb.Location = new System.Drawing.Point(152, 97);
            this.Formatcb.Name = "Formatcb";
            this.Formatcb.Size = new System.Drawing.Size(121, 21);
            this.Formatcb.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Key File:";
            // 
            // KeyFiletb
            // 
            this.KeyFiletb.Location = new System.Drawing.Point(153, 136);
            this.KeyFiletb.Name = "KeyFiletb";
            this.KeyFiletb.Size = new System.Drawing.Size(215, 20);
            this.KeyFiletb.TabIndex = 8;
            // 
            // KeyFilebtn
            // 
            this.KeyFilebtn.Location = new System.Drawing.Point(374, 136);
            this.KeyFilebtn.Name = "KeyFilebtn";
            this.KeyFilebtn.Size = new System.Drawing.Size(75, 23);
            this.KeyFilebtn.TabIndex = 9;
            this.KeyFilebtn.Text = "Browse";
            this.KeyFilebtn.UseVisualStyleBackColor = true;
            this.KeyFilebtn.Click += new System.EventHandler(this.KeyFilebtn_Click);
            // 
            // Generatebtn
            // 
            this.Generatebtn.Location = new System.Drawing.Point(152, 177);
            this.Generatebtn.Name = "Generatebtn";
            this.Generatebtn.Size = new System.Drawing.Size(75, 23);
            this.Generatebtn.TabIndex = 10;
            this.Generatebtn.Text = "Generate";
            this.Generatebtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "IV File:";
            // 
            // IVFiletb
            // 
            this.IVFiletb.Location = new System.Drawing.Point(153, 180);
            this.IVFiletb.Name = "IVFiletb";
            this.IVFiletb.Size = new System.Drawing.Size(215, 20);
            this.IVFiletb.TabIndex = 12;
            // 
            // IVFilebtn
            // 
            this.IVFilebtn.Location = new System.Drawing.Point(374, 180);
            this.IVFilebtn.Name = "IVFilebtn";
            this.IVFilebtn.Size = new System.Drawing.Size(75, 23);
            this.IVFilebtn.TabIndex = 13;
            this.IVFilebtn.Text = "Browse";
            this.IVFilebtn.UseVisualStyleBackColor = true;
            this.IVFilebtn.Click += new System.EventHandler(this.IVFilebtn_Click);
            // 
            // Genbtn
            // 
            this.Genbtn.Location = new System.Drawing.Point(152, 227);
            this.Genbtn.Name = "Genbtn";
            this.Genbtn.Size = new System.Drawing.Size(75, 23);
            this.Genbtn.TabIndex = 14;
            this.Genbtn.Text = "Generate";
            this.Genbtn.UseVisualStyleBackColor = true;
            this.Genbtn.Click += new System.EventHandler(this.Genbtn_Click);
            // 
            // GenKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 450);
            this.Controls.Add(this.Genbtn);
            this.Controls.Add(this.IVFilebtn);
            this.Controls.Add(this.IVFiletb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Generatebtn);
            this.Controls.Add(this.KeyFilebtn);
            this.Controls.Add(this.KeyFiletb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Formatcb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeySizetb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AESModecb);
            this.Controls.Add(this.label1);
            this.Name = "GenKey";
            this.Text = "GenKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AESModecb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeySizetb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Formatcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox KeyFiletb;
        private System.Windows.Forms.Button KeyFilebtn;
        private System.Windows.Forms.Button Generatebtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IVFiletb;
        private System.Windows.Forms.Button IVFilebtn;
        private System.Windows.Forms.Button Genbtn;
    }
}