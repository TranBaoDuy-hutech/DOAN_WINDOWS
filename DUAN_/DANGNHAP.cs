using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUAN_
{
    public partial class frmDANGNHAP : Form
    {
        public frmDANGNHAP()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDANGNHAP_Load(object sender, EventArgs e)
        {
            txtpass.PasswordChar = '*';
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtid.Text;
            string password = txtpass.Text;
            

            // Thực hiện kiểm tra đăng nhập (đây chỉ là ví dụ)
            if (username == "1" && password == "1") // Thay đổi logic kiểm tra thực tế
            {
                MessageBox.Show("Đăng nhập thành công!");
                GIAODIEN f = new GIAODIEN();
                this.Hide();
                f.ShowDialog();
                this.Show();
                
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
            
         
        }
         
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDANGNHAP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("BAN CO MUON THOAT CHUONG TRINH KHONG", "THONG BAO", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;

            }
        }

        private void txbid_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter) // Kiểm tra xem phím Enter có được nhấn không
           {
               btndangnhap.PerformClick(); // Gọi hàm nhấn nút "Đăng nhập"
           }
        }
    }
}
