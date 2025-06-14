namespace DES_GUI
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
            this.DESModecb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KeySizetb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Formatcb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KeyFiletb = new System.Windows.Forms.TextBox();
            this.IVFiletb = new System.Windows.Forms.TextBox();
            this.Generatebtn = new System.Windows.Forms.Button();
            this.BrowseKeybtn = new System.Windows.Forms.Button();
            this.BrowseIVbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 0;
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
            this.DESModecb.Location = new System.Drawing.Point(113, 25);
            this.DESModecb.Name = "DESModecb";
            this.DESModecb.Size = new System.Drawing.Size(121, 21);
            this.DESModecb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key Size:";
            // 
            // KeySizetb
            // 
            this.KeySizetb.Location = new System.Drawing.Point(113, 59);
            this.KeySizetb.Name = "KeySizetb";
            this.KeySizetb.Size = new System.Drawing.Size(121, 20);
            this.KeySizetb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Key Format:";
            // 
            // Formatcb
            // 
            this.Formatcb.FormattingEnabled = true;
            this.Formatcb.Items.AddRange(new object[] {
            "Binary",
            "Hex",
            "Base64"});
            this.Formatcb.Location = new System.Drawing.Point(113, 98);
            this.Formatcb.Name = "Formatcb";
            this.Formatcb.Size = new System.Drawing.Size(121, 21);
            this.Formatcb.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Key File:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "IV File:";
            // 
            // KeyFiletb
            // 
            this.KeyFiletb.Location = new System.Drawing.Point(113, 140);
            this.KeyFiletb.Name = "KeyFiletb";
            this.KeyFiletb.Size = new System.Drawing.Size(238, 20);
            this.KeyFiletb.TabIndex = 8;
            // 
            // IVFiletb
            // 
            this.IVFiletb.Location = new System.Drawing.Point(113, 182);
            this.IVFiletb.Name = "IVFiletb";
            this.IVFiletb.Size = new System.Drawing.Size(238, 20);
            this.IVFiletb.TabIndex = 9;
            // 
            // Generatebtn
            // 
            this.Generatebtn.Location = new System.Drawing.Point(113, 236);
            this.Generatebtn.Name = "Generatebtn";
            this.Generatebtn.Size = new System.Drawing.Size(75, 23);
            this.Generatebtn.TabIndex = 10;
            this.Generatebtn.Text = "Generate";
            this.Generatebtn.UseVisualStyleBackColor = true;
            this.Generatebtn.Click += new System.EventHandler(this.Generatebtn_Click);
            // 
            // BrowseKeybtn
            // 
            this.BrowseKeybtn.Location = new System.Drawing.Point(357, 137);
            this.BrowseKeybtn.Name = "BrowseKeybtn";
            this.BrowseKeybtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseKeybtn.TabIndex = 11;
            this.BrowseKeybtn.Text = "Browse";
            this.BrowseKeybtn.UseVisualStyleBackColor = true;
            this.BrowseKeybtn.Click += new System.EventHandler(this.BrowseKeybtn_Click);
            // 
            // BrowseIVbtn
            // 
            this.BrowseIVbtn.Location = new System.Drawing.Point(357, 179);
            this.BrowseIVbtn.Name = "BrowseIVbtn";
            this.BrowseIVbtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseIVbtn.TabIndex = 12;
            this.BrowseIVbtn.Text = "Browse";
            this.BrowseIVbtn.UseVisualStyleBackColor = true;
            this.BrowseIVbtn.Click += new System.EventHandler(this.BrowseIVbtn_Click);
            // 
            // GenKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 305);
            this.Controls.Add(this.BrowseIVbtn);
            this.Controls.Add(this.BrowseKeybtn);
            this.Controls.Add(this.Generatebtn);
            this.Controls.Add(this.IVFiletb);
            this.Controls.Add(this.KeyFiletb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Formatcb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KeySizetb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DESModecb);
            this.Controls.Add(this.label1);
            this.Name = "GenKey";
            this.Text = "GenKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DESModecb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeySizetb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Formatcb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KeyFiletb;
        private System.Windows.Forms.TextBox IVFiletb;
        private System.Windows.Forms.Button Generatebtn;
        private System.Windows.Forms.Button BrowseKeybtn;
        private System.Windows.Forms.Button BrowseIVbtn;
    }
}