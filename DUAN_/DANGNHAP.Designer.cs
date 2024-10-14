namespace DUAN_
{
    partial class frmDANGNHAP
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
            this.txtpass = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btndangnhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(139, 132);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(234, 22);
            this.txtpass.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnthoat);
            this.panel1.Controls.Add(this.btndangnhap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.txtpass);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 243);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnthoat
            // 
            this.btnthoat.Location = new System.Drawing.Point(279, 180);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(75, 23);
            this.btnthoat.TabIndex = 4;
            this.btnthoat.Text = "THOAT";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btndangnhap
            // 
            this.btndangnhap.Location = new System.Drawing.Point(139, 180);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(101, 23);
            this.btndangnhap.TabIndex = 3;
            this.btndangnhap.Text = "DANG NHAP";
            this.btndangnhap.UseVisualStyleBackColor = true;
            this.btndangnhap.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "PASS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(139, 65);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(234, 22);
            this.txtid.TabIndex = 0;
            this.txtid.TextChanged += new System.EventHandler(this.txbid_TextChanged);
            // 
            // frmDANGNHAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(461, 276);
            this.Controls.Add(this.panel1);
            this.Name = "frmDANGNHAP";
            this.Text = "ĐĂNG NHẬP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDANGNHAP_FormClosing);
            this.Load += new System.EventHandler(this.frmDANGNHAP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnthoat;
    }
}

