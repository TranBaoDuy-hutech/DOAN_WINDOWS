using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUAN_
{
    public partial class QUENMK : Form
    {
        private string defaultUsername = "1006738"; // Đặt tên đăng nhập mặc định
        private string defaultPassword = "8153"; // Đặt mật khẩu mặc định

        public QUENMK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmailOrPhone.Text;

            // Bước 1: Kiểm tra thông tin người dùng có tồn tại không
            if (CheckUserInDatabase(username, email))
            {
                // Bước 2: Tạo mật khẩu mới hoặc mã xác minh
                string newPassword = GenerateNewPassword();

                // Bước 3: Gửi mật khẩu mới qua email
                if (SendEmail(email, newPassword))
                {
                    lblStatus.Text = "Mật khẩu mới đã được gửi đến email của bạn.";
                }
                else
                {
                    lblStatus.Text = "Không thể gửi email. Vui lòng thử lại.";
                }

                // Bước 4: Cập nhật mật khẩu mới vào cơ sở dữ liệu
                UpdatePasswordInDatabase(username, newPassword);
            }
            else
            {
                lblStatus.Text = "Tên đăng nhập hoặc email không đúng.";
            }

        }
        private string GenerateNewPassword()
        {
            return "8153"; // Hoặc có thể tự động sinh mật khẩu phức tạp hơn
        }
        private bool CheckUserInDatabase(string username, string email)
        {
            // Giả lập kiểm tra thông tin trong cơ sở dữ liệu
            // Thay bằng mã thực tế để truy vấn cơ sở dữ liệu
            return username == "1006738" && email == "baoduy10072004@gmail.com";
        }
        private void UpdatePasswordInDatabase(string username, string newPassword)
        {
            // Thực hiện truy vấn để cập nhật mật khẩu vào cơ sở dữ liệu
            // Ví dụ: UPDATE Users SET Password = newPassword WHERE Username = username
        }

        // Ví dụ hàm gửi email (cần tích hợp API hoặc SMTP server)
        private bool SendEmail(string recipientEmail, string newPassword)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("baoduy10072004@gmail.com", "ihmu fsap rwam ljqm");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("baoduy10072004@gmail.com");
                mailMessage.To.Add(recipientEmail);
                mailMessage.Subject = "Đặt lại mật khẩu";
                mailMessage.Body = $"Mật khẩu mới của bạn là: {newPassword}";

                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi email: " + ex.Message);
                return false;
            }
        }

    }
}
