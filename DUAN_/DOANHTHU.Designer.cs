namespace DUAN_
{
    partial class DOANHTHU
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
            this.dgvct_hd = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.txtMaHoaDonTim = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdthu = new System.Windows.Forms.TextBox();
            this.dgvtimhd = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dataNgay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvct_hd)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtimhd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvct_hd
            // 
            this.dgvct_hd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvct_hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvct_hd.Location = new System.Drawing.Point(12, 54);
            this.dgvct_hd.Name = "dgvct_hd";
            this.dgvct_hd.Size = new System.Drawing.Size(631, 188);
            this.dgvct_hd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "DOANH THU NGAY, CT_HOADON";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.dataNgay);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.txtMaHoaDonTim);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtdthu);
            this.panel1.Location = new System.Drawing.Point(649, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 463);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(157, 265);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "IN LAI";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtMaHoaDonTim
            // 
            this.txtMaHoaDonTim.Location = new System.Drawing.Point(82, 216);
            this.txtMaHoaDonTim.Name = "txtMaHoaDonTim";
            this.txtMaHoaDonTim.Size = new System.Drawing.Size(46, 20);
            this.txtMaHoaDonTim.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "TIM HD";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "XUAT EX";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(25, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "KET DOANH THU NGAY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "TONG DOANH THU";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtdthu
            // 
            this.txtdthu.Location = new System.Drawing.Point(157, 62);
            this.txtdthu.Name = "txtdthu";
            this.txtdthu.Size = new System.Drawing.Size(119, 20);
            this.txtdthu.TabIndex = 0;
            this.txtdthu.TextChanged += new System.EventHandler(this.txtdthu_TextChanged);
            // 
            // dgvtimhd
            // 
            this.dgvtimhd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgvtimhd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtimhd.Location = new System.Drawing.Point(12, 367);
            this.dgvtimhd.Name = "dgvtimhd";
            this.dgvtimhd.Size = new System.Drawing.Size(630, 150);
            this.dgvtimhd.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(33, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "HOA DON DUOC TIM THAY";
            // 
            // dataNgay
            // 
            this.dataNgay.Location = new System.Drawing.Point(25, 16);
            this.dataNgay.Name = "dataNgay";
            this.dataNgay.Size = new System.Drawing.Size(200, 20);
            this.dataNgay.TabIndex = 7;
            this.dataNgay.ValueChanged += new System.EventHandler(this.dataNgay_ValueChanged);
            // 
            // DOANHTHU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 532);
            this.Controls.Add(this.dgvtimhd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvct_hd);
            this.Name = "DOANHTHU";
            this.Text = "DOANHTHU";
            this.Load += new System.EventHandler(this.DOANHTHU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvct_hd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtimhd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvct_hd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdthu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMaHoaDonTim;
        private System.Windows.Forms.DataGridView dgvtimhd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dataNgay;
    }
}