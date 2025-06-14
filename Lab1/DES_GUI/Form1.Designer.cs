namespace DES_GUI
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
            this.label2 = new System.Windows.Forms.Label();
            this.GenKeybtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Encryptbtn = new System.Windows.Forms.Button();
            this.Decryptbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "DES GUI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Task1";
            // 
            // GenKeybtn
            // 
            this.GenKeybtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenKeybtn.Location = new System.Drawing.Point(12, 81);
            this.GenKeybtn.Name = "GenKeybtn";
            this.GenKeybtn.Size = new System.Drawing.Size(91, 46);
            this.GenKeybtn.TabIndex = 2;
            this.GenKeybtn.Text = "Generate Key and IV";
            this.GenKeybtn.UseVisualStyleBackColor = true;
            this.GenKeybtn.Click += new System.EventHandler(this.GenKeybtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "23520669 - Phạm Lê Đăng Kha";
            // 
            // Encryptbtn
            // 
            this.Encryptbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Encryptbtn.Location = new System.Drawing.Point(109, 81);
            this.Encryptbtn.Name = "Encryptbtn";
            this.Encryptbtn.Size = new System.Drawing.Size(91, 46);
            this.Encryptbtn.TabIndex = 4;
            this.Encryptbtn.Text = "Encrypt";
            this.Encryptbtn.UseVisualStyleBackColor = true;
            this.Encryptbtn.Click += new System.EventHandler(this.Encryptbtn_Click);
            // 
            // Decryptbtn
            // 
            this.Decryptbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Decryptbtn.Location = new System.Drawing.Point(206, 81);
            this.Decryptbtn.Name = "Decryptbtn";
            this.Decryptbtn.Size = new System.Drawing.Size(91, 46);
            this.Decryptbtn.TabIndex = 5;
            this.Decryptbtn.Text = "Decrypt";
            this.Decryptbtn.UseVisualStyleBackColor = true;
            this.Decryptbtn.Click += new System.EventHandler(this.Decryptbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "NT219.P22.ANTT";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 234);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Decryptbtn);
            this.Controls.Add(this.Encryptbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GenKeybtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GenKeybtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Encryptbtn;
        private System.Windows.Forms.Button Decryptbtn;
        private System.Windows.Forms.Label label4;
    }
}

