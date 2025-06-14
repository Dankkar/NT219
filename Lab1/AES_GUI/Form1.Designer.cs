namespace AES_GUI
{
    partial class Dashboard
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
            this.GenKeybtn = new System.Windows.Forms.Button();
            this.Encryptbtn = new System.Windows.Forms.Button();
            this.Decryptbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "AES GUI";
            // 
            // GenKeybtn
            // 
            this.GenKeybtn.Location = new System.Drawing.Point(69, 67);
            this.GenKeybtn.Name = "GenKeybtn";
            this.GenKeybtn.Size = new System.Drawing.Size(95, 45);
            this.GenKeybtn.TabIndex = 1;
            this.GenKeybtn.Text = "Generate Key and IV";
            this.GenKeybtn.UseVisualStyleBackColor = true;
            this.GenKeybtn.Click += new System.EventHandler(this.GenKeybtn_Click);
            // 
            // Encryptbtn
            // 
            this.Encryptbtn.Location = new System.Drawing.Point(204, 67);
            this.Encryptbtn.Name = "Encryptbtn";
            this.Encryptbtn.Size = new System.Drawing.Size(95, 45);
            this.Encryptbtn.TabIndex = 2;
            this.Encryptbtn.Text = "Encrypt";
            this.Encryptbtn.UseVisualStyleBackColor = true;
            this.Encryptbtn.Click += new System.EventHandler(this.Encryptbtn_Click);
            // 
            // Decryptbtn
            // 
            this.Decryptbtn.Location = new System.Drawing.Point(342, 67);
            this.Decryptbtn.Name = "Decryptbtn";
            this.Decryptbtn.Size = new System.Drawing.Size(95, 45);
            this.Decryptbtn.TabIndex = 3;
            this.Decryptbtn.Text = "Decrypt";
            this.Decryptbtn.UseVisualStyleBackColor = true;
            this.Decryptbtn.Click += new System.EventHandler(this.Decryptbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(280, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phạm Lê Đăng Kha - 23520669";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(169, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "NT219.P21.ANTT";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 259);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Decryptbtn);
            this.Controls.Add(this.Encryptbtn);
            this.Controls.Add(this.GenKeybtn);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GenKeybtn;
        private System.Windows.Forms.Button Encryptbtn;
        private System.Windows.Forms.Button Decryptbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

