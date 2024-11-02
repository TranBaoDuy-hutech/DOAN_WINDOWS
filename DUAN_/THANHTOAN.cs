using DOAN_BANHSACH.BUS;
using DOAN_BANSACH.DAL.Entity;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DOAN_BANHSACH.BUS.SachService;
using static QRCoder.PayloadGenerator;

namespace DUAN_
{
  
    public partial class THANHTOAN : Form
    {
        private readonly SachService _sachService;
        private PrintDocument printDocument;
        private PrintDialog printDialog;
        

        public THANHTOAN()
        {
            InitializeComponent();
            _sachService = new SachService();
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage1);
            printDialog = new PrintDialog();            
            
        }
        private void PrintDocument_PrintPage1(object sender, PrintPageEventArgs e)
        {
            // Example data, replace with your actual invoice data

            var CHITIETHOADON =    $"CHI TIET HOA DON\n\n" +
                                   $"NGAY IN:     {txtNgayLap.Value.ToString("dd/MM/yyyy")}\n" +
                                   $"MA SACH:     {txtid.Text}\n" +
                                   $"TEN SACH:    {txtts.Text}\n" +
                                   $"SO LUONG:    {txtsl.Text}\n" +
                                   $"TONG TIEN:   {txttongtien.Text}\n\n" +
                                   $"TIEN NHAN:   {txttiennhan.Text}\n"+
                                   $"TRA LAI:     {txttralai.Text}\n\n" +
                                   "CAM ON BAN DA MUA HANG";
            e.Graphics.DrawString(CHITIETHOADON, new Font("Arial", 20), Brushes.Black, 100, 100);
        }
        private void PrintInvoice()
        {
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void THANHTOAN_Load(object sender, EventArgs e)
        {
            LoadDataSACH();
            LoadDataCT_HoaDon();
            TinhTongTien();
            
        }
        private void LoadDataCT_HoaDon()
        {
            var service = new CT_HoaDonService();
            var data = service.GetAllCT_HoaDon();

            var dataTable = new DataTable();
            dataTable.Columns.Add("MAHOADON", typeof(int));
           

            foreach (var item in data)
            {
                dataTable.Rows.Add(item.MAHD);
            }
            dataGridView3.DataSource = dataTable;
        }
        private void LoadDataSACH()
        {
            using (var context = new BansachModel())
            {
                var data = context.SACH.ToList();  // Chuyển đổi danh sách thành DataTable
                var dataTable = new DataTable();

                dataTable.Columns.Add("MASACH", typeof(string));
                dataTable.Columns.Add("TENSACH", typeof(string));
                dataTable.Columns.Add("SOLUONG", typeof(string));
                dataTable.Columns.Add("GIABAN", typeof(string));
                foreach (var item in data)
                {

                    dataTable.Rows.Add(item.MASACH, item.TENSACH, item.SL, item.GIA);

                }
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                txtid.Text = selectedRow.Cells["MASACH"].Value.ToString();
                txtts.Text = selectedRow.Cells["TENSACH"].Value.ToString();
                txtgia.Text = selectedRow.Cells["GIABAN"].Value.ToString();


            }
        }
        private void TinhTongTien()
        {
            // Kiểm tra nếu các ô trống hoặc không phải là số hợp lệ
            if (decimal.TryParse(txtsl.Text, out decimal soLuong) && decimal.TryParse(txtgia.Text, out decimal gia))
            {
                decimal tongTien = soLuong * gia; // Tính tổng tiền
                txttongtien.Text = tongTien.ToString("N0"); // Hiển thị vào txtTongTien với định dạng 2 chữ số sau dấu thập phân
            }
            else
            {
                txttongtien.Text = "0"; // Đặt giá trị mặc định là 0 nếu nhập sai
            }
        }

        private void txttt_Click(object sender, EventArgs e)
        {
            TinhTongTien();

        }
        public void DeductStockAfterPayment(int maSach, int quantitySold)
        {
            using (var context = new BansachModel())
            {
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                if (sach != null && sach.SL >= quantitySold) // Kiểm tra đủ số lượng
                {
                    sach.SL -= quantitySold; // Trừ số lượng
                    context.SaveChanges(); // Lưu thay đổi
                }
                else
                {
                    // Có thể thông báo không đủ hàng nếu cần thiết
                }
            }
        }
        public bool CheckStockAvailability(int maSach, int quantitySold)
        {
            using (var context = new BansachModel())
            {
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                return sach != null && sach.SL >= quantitySold; // Trả về true nếu đủ hàng
            }
        }
        public void T(int maSach, int quantitySold)
        {
            using (var context = new BansachModel())
            {
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                if (sach != null)
                {
                    sach.SL -= quantitySold; // Trừ số lượng
                    context.SaveChanges(); // Lưu thay đổi
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {           
            int maSach = int.Parse(txtid.Text); // Mã sách
            int quantitySold = int.Parse(txtsl.Text); // Số lượng đã bán                                                    
            // Kiểm tra xem số tiền nhận có đủ để thanh toán không
            decimal totalAmount = decimal.Parse(txttongtien.Text); // Tổng tiền từ TextBox
            decimal receivedAmount = decimal.Parse(txttiennhan.Text); // Số tiền nhận từ TextBox

            if (receivedAmount < totalAmount)
            {
                MessageBox.Show("Số tiền nhận không đủ để thanh toán. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu số tiền không đủ
            }         
            // Tạo đối tượng hóa đơn chi tiết
            var hoaDon = new CT_HOADON
            {
                MAHD = int.Parse(txtMAHD.Text),
                NGAYLAP = DateTime.Parse(txtNgayLap.Text),
                MASACH = maSach,
                SOLUONG = quantitySold,
                TONGTIEN = (int?)decimal.Parse(txttongtien.Text),
                TIENNHAN = int.Parse(txttiennhan.Text),
                TIENTHUA = (int?)decimal.Parse(txttralai.Text)
            };

            // Tạo dịch vụ hóa đơn và thêm hóa đơn
            var service = new CT_HoaDonService();
            service.Add(hoaDon);

            // Tạo thể hiện của SachService để quản lý sách
            var sachService = new SachService();

            // Kiểm tra số lượng sách trong kho
            if (CheckStockAvailability(maSach, quantitySold))
            {
                // Trừ số lượng sách sau khi thanh toán
                DeductStockAfterPayment(maSach, quantitySold);

                // Hiển thị thông báo thanh toán thành công
                MessageBox.Show("Thanh toán thành công! Cảm ơn bạn đã mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Thông báo không đủ số lượng sách
                MessageBox.Show("Không đủ số lượng sách trong kho để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadDataSACH();
            LoadDataCT_HoaDon();
        }



        private void txtsl_TextChanged(object sender, EventArgs e)
        {
            TinhTongTien();
        }

        
        private void TinhTienThua()
        {
            // Kiểm tra nếu txtTongTien và txtTienKhachTra có giá trị hợp lệ
            if (decimal.TryParse(txttongtien.Text, out decimal tongTien) && decimal.TryParse(txttiennhan.Text, out decimal tienKhachTra))
            {
                // Tính tiền thừa
                decimal tienThua = tienKhachTra - tongTien;
                txttralai.Text = tienThua.ToString("N0"); // Hiển thị tiền thừa với 2 chữ số thập phân
            }
            else
            {
                txttralai.Text = "0"; // Nếu dữ liệu không hợp lệ, đặt mặc định là 0
            }
        }

        private void TinhTienThuaall()
        {
            // Kiểm tra nếu txtTongTien và txtTienKhachTra có giá trị hợp lệ
            if (decimal.TryParse(txtalltt.Text, out decimal tongTien) && decimal.TryParse(txtalltn.Text, out decimal tienKhachTra))
            {
                // Tính tiền thừa
                decimal tienThua = tienKhachTra - tongTien;
                txttralai.Text = tienThua.ToString("N0"); // Hiển thị tiền thừa với 2 chữ số thập phân
            }
            else
            {
                txttralai.Text = "0"; // Nếu dữ liệu không hợp lệ, đặt mặc định là 0
            }
        }
        private void txttiennhan_TextChanged(object sender, EventArgs e)
        {
            TinhTienThua();   
        }

        private void txttm_Click(object sender, EventArgs e)
        {
            DOANHTHU F = new DOANHTHU();
            this.Hide();
            F.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tất cả các TextBox có dữ liệu chưa
            if (string.IsNullOrWhiteSpace(txtMAHD.Text) ||
                string.IsNullOrWhiteSpace(txtid.Text) ||
                string.IsNullOrWhiteSpace(txtsl.Text) ||
                string.IsNullOrWhiteSpace(txttongtien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Thiết lập các cột cho dataGridView2 (nếu chưa được thêm)
            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].Name = "Mã hóa đơn";
            dataGridView2.Columns[1].Name = "Mã sách";
            dataGridView2.Columns[2].Name = "Tên sách";
            dataGridView2.Columns[3].Name = "Số lượng";
            dataGridView2.Columns[4].Name = "Tổng tiền";
            dataGridView2.Columns[5].Name = "Ngày lập";
         //   dataGridView2.Columns[6].Name = "Tien nhan";
         //   dataGridView2.Columns[7].Name = "Tien thua";

            // Lấy dữ liệu từ DateTimePicker và định dạng ngày tháng (nếu cần)
            string ngayLap = txtNgayLap.Value.ToString("dd/MM/yyyy");

            // Thêm dòng mới vào dataGridView2
            dataGridView2.Rows.Add(txtMAHD.Text, txtid.Text, txtts.Text, txtsl.Text, txttongtien.Text, ngayLap, txttiennhan.Text,txttralai.Text);

            // Xóa dữ liệu trong các TextBox sau khi lưu            
            txtid.Clear();
            txtts.Clear();
            txtsl.Clear();
            txttongtien.Clear();
            txtNgayLap.Value = DateTime.Now; // Đặt lại DateTimePicker về ngày hiện tại
            CalculateTotalRevenue();

            // Hiển thị thông báo lưu thành công
            MessageBox.Show("Đã lưu thông tin vào danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không chọn tiêu đề
            {
                var selectedRow = dataGridView2.Rows[e.RowIndex];

                // Gán dữ liệu của dòng vào các TextBox
                txtMAHD.Text = selectedRow.Cells["Mã hóa đơn"].Value.ToString();
                txtNgayLap.Text = selectedRow.Cells["Ngày lập"].Value.ToString();
                txtts.Text = selectedRow.Cells["Tên sách"].Value.ToString();
                txtid.Text = selectedRow.Cells["Mã sách"].Value.ToString();
                txtsl.Text = selectedRow.Cells["Số lượng"].Value.ToString();
                txttongtien.Text = selectedRow.Cells["Tổng tiền"].Value.ToString();
             //   txttiennhan.Text = selectedRow.Cells["Tien nhan"].Value.ToString(); // Để trống để người dùng nhập
             //   txttralai.Text = selectedRow.Cells["Tien thua"].Value.ToString();   // Để trống để cập nhật sau
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Khởi tạo danh sách hóa đơn để lưu trữ các sách trong hóa đơn
            var danhSachHoaDon = new List<CT_HOADON>();
            decimal totalAmount = decimal.Parse(txtalltt.Text); // Tổng tiền từ TextBox
            decimal receivedAmount = decimal.Parse(txtalltn.Text); // Số tiền nhận từ TextBox

            if (receivedAmount < totalAmount)
            {
                MessageBox.Show("Số tiền nhận không đủ để thanh toán. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu số tiền không đủ
            }

            // Duyệt qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["Mã hóa đơn"].Value != null && row.Cells["Mã sách"].Value != null)
                {
                    // Lấy dữ liệu từ từng cột trong dòng
                    int maHoaDon = int.Parse(row.Cells["Mã hóa đơn"].Value.ToString());
                    int maSach =   int.Parse(row.Cells["Mã sách"].Value.ToString());
                    int soLuong =  int.Parse(row.Cells["Số lượng"].Value.ToString());
                    decimal tongTien = decimal.Parse(row.Cells["Tổng tiền"].Value.ToString());                    
                    DateTime ngayLap = DateTime.Parse(row.Cells["Ngày lập"].Value.ToString());

                    // Tạo đối tượng chi tiết hóa đơn và thêm vào danh sách
                    var hoaDon = new CT_HOADON
                    {
                        MAHD = maHoaDon,
                        MASACH = maSach,
                        SOLUONG = soLuong,
                        TONGTIEN = (int?)decimal.Parse(txtalltt.Text),
                        TIENNHAN = int.Parse(txtalltn.Text),
                        TIENTHUA = (int?)decimal.Parse(txttralai.Text),
                        NGAYLAP = ngayLap
                    };
                    danhSachHoaDon.Add(hoaDon);

                    var service = new CT_HoaDonService();                    
                    service.Add(hoaDon);

                }
            }
            
            // Thực hiện thanh toán cho toàn bộ danh sách hóa đơn
            ThanhToanDanhSachHoaDon(danhSachHoaDon);
        }

        // Phương thức thanh toán cho danh sách hóa đơn
        private void ThanhToanDanhSachHoaDon(List<CT_HOADON> danhSachHoaDon)
        {
            foreach (var hoaDon in danhSachHoaDon)
            {
                int maSach = hoaDon.MASACH;
                int soLuongMua = hoaDon.SOLUONG ?? 0;

                // Kiểm tra tồn kho cho từng sách
                if (!CheckStockAvailability(maSach, soLuongMua))
                {
                    MessageBox.Show($"Không đủ số lượng sách có mã {maSach} trong kho để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Trừ số lượng sách trong kho
                DeductStockAfterPayment(maSach, soLuongMua);
            }

            // Thông báo thanh toán thành công
            MessageBox.Show("Thanh toán toàn bộ hóa đơn thành công! Cảm ơn bạn đã mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại dữ liệu hiển thị
            LoadDataSACH();
            LoadDataCT_HoaDon();
        }
        private void CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;

            // Duyệt qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[4].Value != null) // Kiểm tra nếu ô không rỗng
                {
                    // Cộng giá trị ở cột 3 (index 3)
                    totalRevenue += Convert.ToDecimal(row.Cells[4].Value);
                }
            }

            // Chuyển totalRevenue sang kiểu int
            int totalRevenueInt = (int)totalRevenue;

            // Gán tổng doanh thu vào TextBox và định dạng kiểu tiền tệ
            txtalltt.Text = totalRevenueInt.ToString("N0"); // Định dạng không có số thập phân

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateTotalRevenue();
           
        }

        private void txtalltn_TextChanged(object sender, EventArgs e)
        {
            TinhTienThuaall();
        }
       

        private void txtMOMO_Click(object sender, EventArgs e)
        {
            // Lấy số tiền và mã hóa đơn từ TextBox
            string amount = txttongtien.Text; // Giả sử txtSoTien chứa số tiền
            string invoiceId = txtMAHD.Text; // Giả sử txtMaHD chứa mã hóa đơn

            // Thông tin cho QR Code (thay thế số điện thoại với tài khoản nhận tiền)
            string phoneNumber = "0329810650"; // Thay thế bằng số điện thoại thực tế của tài khoản MoMo
            string qrCodeContent = $"momo://payment?amount={amount}&invoiceId={invoiceId}&phone={phoneNumber}";

            // Tạo mã QR
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrGenerator.CreateQrCode(qrCodeContent, QRCodeGenerator.ECCLevel.Q))
                {
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(5);
                        // Hiển thị mã QR trong PictureBox (giả sử bạn đã thêm PictureBox vào form)
                        pictureBoxQRCode.Image = qrCodeImage;
                    }
                }
            }
        }
    }


}
