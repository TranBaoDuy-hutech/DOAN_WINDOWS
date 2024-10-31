using DOAN_BANHSACH.BUS;
using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUAN_
{
    public partial class TRANGCHU : Form
    {
        private readonly SachService _sachService;
        private readonly LuongService _luongService;
        private PrintDocument printDocument;
        private PrintDocument printDocument1;
        private PrintDialog printDialog;
        private PrintDialog printDialog1;

        public TRANGCHU()
        {
            InitializeComponent();
            _sachService = new SachService();
            _luongService = new LuongService();
            printDocument = new PrintDocument();
            printDocument1 = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage1);
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage2);
            printDialog = new PrintDialog();
            printDialog1 = new PrintDialog();
        }
        private void PrintDocument_PrintPage1(object sender, PrintPageEventArgs e)
        {
            // Example data, replace with your actual invoice data

            var CHITIETHOADON = $"CHI TIET HOA DON\n\n" +
                                   $"NGAY IN:          {dateTimePicker1.Value.ToString("dd/MM/yyyy")}\n" +
                                   $"SO HOA DON:       {txtMaHoaDon.Text}\n" +
                                   $"NGAY LAP HOA DON: {txtNgayLap.Value.ToString("dd/MM/yyyy")}\n" +
                                   $"MA NHAN VIEN:     {txtHDtt.Text}\n" +
                                   $"TEN KHACH HANG:   {txtHDmasach.Text}\n\n" +
                                   "CAM ON BAN DA MUA HANG";
            e.Graphics.DrawString(CHITIETHOADON, new Font("Arial", 20), Brushes.Black, 100, 100);
        }

        private void PrintDocument_PrintPage2(object sender, PrintPageEventArgs e)
        {
            // Tạo nội dung cho phiếu lương

            var phieuLuong =
                            $"PHIEU LUONG THANG\n\n" +
                            $"NGAY IN:        {dateTimePicker1.Value.ToString("dd/MM/yyyy")}\n" +
                            $"Mã Lương:       {txtMaPhieuLuong.Text}\n" +
                            $"Mã Nhân Viên:   {txtLuongMANV.Text}\n" +
                            $"Lương Tháng:    {txtLuongThang.Text}\n";


            e.Graphics.DrawString(phieuLuong, new Font("Arial", 20), Brushes.Black, 100, 100);
        }
        private void PrintInvoice()
        {
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintSalarySlip()
        {
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void btnInPhieuLuong_Click(object sender, EventArgs e)
        {

            PrintSalarySlip();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndouong_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MUCKHAC F = new MUCKHAC();
            this.Hide();
            F.ShowDialog();
            this.Show();
        }


        private void TRANGCHU_Load(object sender, EventArgs e)
        {
            LoadDataSACH();
            LoadDataTHELOAI();
            LoadDataPhieuNhap();
            LoadDataHoaDon();
            LoadNhanVien();
            LoadLuong();

        }
        private void LoadDataSACH()
        {
            using (var context = new BansachModel())
            {
                var data = context.SACH.ToList();  // Chuyển đổi danh sách thành DataTable
                var dataTable = new DataTable();

                dataTable.Columns.Add("MASACH", typeof(string));
                dataTable.Columns.Add("TENSACH", typeof(string));
                dataTable.Columns.Add("THELOAI", typeof(string));
                dataTable.Columns.Add("TACGIA", typeof(string));
                dataTable.Columns.Add("SOLUONG", typeof(string));
                dataTable.Columns.Add("GIABAN", typeof(string));


                foreach (var item in data)
                {

                    dataTable.Rows.Add(item.MASACH, item.TENSACH, item.TENTHELOAI, item.TACGIA, item.SL, item.GIA);

                }

                // Gán DataTable cho DataGridView trong TabPage
                dgvSach.DataSource = dataTable;

            }
        }
        private void LoadDataTHELOAI()
        {
            var service = new TheLoaiService();
            var data = service.GetAllTheLoai();

            var dataTable = new DataTable();
            dataTable.Columns.Add("MATHELOAISACH", typeof(string));
            dataTable.Columns.Add("TENTHELOAISACH", typeof(string));

            foreach (var item in data)
            {
                dataTable.Rows.Add(item.MATHELOAISACH, item.TENTHELOAISACH);
            }

            dgvTheloai.DataSource = dataTable;
        }
        private void LoadDataPhieuNhap()
        {
            var service = new CT_PhieuNhapService();
            var data = service.GetAllCT_PHIEUNHAP();

            var dataTable = new DataTable();
            dataTable.Columns.Add("MAPHIEUNHAP", typeof(int));
            dataTable.Columns.Add("NGAYNHAP", typeof(DateTime));
            dataTable.Columns.Add("MASACH", typeof(string));
            dataTable.Columns.Add("SOLUONG", typeof(string));

            foreach (var item in data)
            {
                dataTable.Rows.Add(item.MAPHIEUNHAP,item.NGAYNHAP, item.MASACH, item.SOLUONG);
            }

            dgvPhieunhap.DataSource = dataTable;
        }

        private void AddSach(int maSach, string tenSach, string theLoai, string tacGia, int soLuong, decimal giaBan)
        {
            using (var context = new BansachModel())
            {
                // Tạo một đối tượng sách mới
                var sach = new SACH
                {
                    MASACH = maSach,
                    TENSACH = tenSach,
                    TENTHELOAI = theLoai,
                    TACGIA = tacGia,
                    SL = soLuong,
                    GIA = giaBan
                };

                // Thêm đối tượng sách vào DbSet và lưu thay đổi
                context.SACH.Add(sach);
                context.SaveChanges();
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox (hoặc các điều khiển nhập khác)
            int maSach = int.Parse(txtMaSach.Text);
            string tenSach = txttensach.Text;
            string theLoai = txtloaisach.Text;
            string tacGia = txttacgia.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal giaBan = decimal.Parse(txtGiaBan.Text);

            // Gọi phương thức thêm sách
            AddSach(maSach, tenSach, theLoai, tacGia, soLuong, giaBan);

            // Tải lại dữ liệu vào DataGridView
            LoadDataSACH();
        }
        private void EditSach(int maSach, string tenSach, string theLoai, string tacGia, int soLuong, decimal giaBan)
        {
            using (var context = new BansachModel())
            {
                // Tìm sách theo mã sách
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                if (sach != null)
                {
                    // Cập nhật thông tin
                    sach.TENSACH = tenSach;
                    sach.TENTHELOAI = theLoai;
                    sach.TACGIA = tacGia;
                    sach.SL = soLuong;
                    sach.GIA = giaBan;

                    // Lưu thay đổi
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách với mã này.");
                }
            }
        }


        private void btnsua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox (hoặc các điều khiển nhập khác)
            int maSach = int.Parse(txtMaSach.Text);
            string tenSach = txttensach.Text;
            string theLoai = txtloaisach.Text;
            string tacGia = txttacgia.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal giaBan = decimal.Parse(txtGiaBan.Text);
            // Gọi phương thức sửa sách
            EditSach(maSach, tenSach, theLoai, tacGia, soLuong, giaBan);
            // Tải lại dữ liệu vào DataGridView
            LoadDataSACH();

        }
        private void DeleteSach(int maSach)
        {
            using (var context = new BansachModel())
            {
                // Tìm sách theo mã sách
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                if (sach != null)
                {
                    context.SACH.Remove(sach);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách với mã này.");
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            // Lấy mã sách từ TextBox
            int maSach = int.Parse(txtMaSach.Text);

            // Gọi phương thức xóa sách
            DeleteSach(maSach);

            // Tải lại dữ liệu vào DataGridView
            LoadDataSACH();
        }


        private void dgvSach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the clicked cell is not a header cell
            if (e.RowIndex >= 0)
            {
                // Get the currently selected row
                var selectedRow = dgvSach.Rows[e.RowIndex];

                // Populate the TextBoxes with data from the selected row
                txtMaSach.Text = selectedRow.Cells["MASACH"].Value.ToString();
                txttensach.Text = selectedRow.Cells["TENSACH"].Value.ToString();
                txtloaisach.Text = selectedRow.Cells["THELOAI"].Value.ToString();
                txttacgia.Text = selectedRow.Cells["TACGIA"].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells["SOLUONG"].Value.ToString();
                txtGiaBan.Text = selectedRow.Cells["GIABAN"].Value.ToString();
                TinhTongTien();
            }
        }

        private void btnpnthem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaPhieuNhap.Text, out int maPhieuNhap) &&
                DateTime.TryParse(txtNgayNhap.Text, out DateTime ngayNhap) &&
                int.TryParse(txtPNmasacch.Text, out int maSach) && // Thêm kiểm tra cho mã sách
                int.TryParse(txtPNsl.Text, out int soLuong)) // Thêm kiểm tra cho số lượng
            {
                var phieuNhap = new CT_PHIEUNHAP
                {
                    MAPHIEUNHAP = maPhieuNhap,
                    NGAYNHAP = ngayNhap,
                    MASACH = maSach, // Gán mã sách
                    SOLUONG = soLuong // Gán số lượng
                };

                var service = new CT_PhieuNhapService(); // Đảm bảo sử dụng dịch vụ đúng
                service.Add(phieuNhap);
                LoadDataPhieuNhap(); // Refresh data
                LoadDataSACH();
            }
            else
            {
                MessageBox.Show("Mã phiếu nhập, ngày nhập, mã sách hoặc số lượng không hợp lệ.");
            }
        }


        private void btnpnxoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaPhieuNhap.Text, out int maPhieuNhap) &&
                int.TryParse(txtPNmasacch.Text, out int maSach)) // Thêm mã sách nếu cần
            {
                var service = new CT_PhieuNhapService();
                try
                {
                    service.Delete(maPhieuNhap, maSach); // Gọi phương thức xóa
                    LoadDataPhieuNhap(); // Refresh data
                    MessageBox.Show("Xóa phiếu nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Mã phiếu nhập hoặc mã sách không hợp lệ.");
            }
            LoadDataSACH();
        }

        /*


        private void btnpnsua_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaPhieuNhap.Text, out int maPhieuNhap) &&
                int.TryParse(txtPNmasacch.Text, out int maSach) && // Thêm mã sách nếu cần
                DateTime.TryParse(txtNgayNhap.Text, out DateTime ngayNhap) &&
                int.TryParse(txtPNsl.Text, out int soLuong)) // Giả sử bạn có ô nhập số lượng
            {
                var phieuNhap = new CT_PHIEUNHAP
                {
                    MAPHIEUNHAP = maPhieuNhap,
                    MASACH = maSach,
                    NGAYNHAP = ngayNhap,
                    SOLUONG = soLuong // Cập nhật số lượng nếu cần
                };

                var service = new CT_PhieuNhapService();
                service.Update(phieuNhap);
                LoadDataPhieuNhap(); // Refresh data
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ.");
            }
        }

        */
        private void btnpnsua_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaPhieuNhap.Text, out int maPhieuNhap) &&
                int.TryParse(txtPNmasacch.Text, out int maSach) &&
                DateTime.TryParse(txtNgayNhap.Text, out DateTime ngayNhap) &&
                int.TryParse(txtPNsl.Text, out int soLuong))
            {
                var phieuNhap = new CT_PHIEUNHAP
                {
                    MAPHIEUNHAP = maPhieuNhap,
                    MASACH = maSach,
                    NGAYNHAP = ngayNhap,
                    SOLUONG = soLuong
                };

                var service = new CT_PhieuNhapService();
                service.UpdateCTPhieuNhap(phieuNhap);
                LoadDataPhieuNhap(); // Làm mới dữ liệu
                LoadDataSACH();
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ.");
            }
        }




        private void dgvPhieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvPhieunhap.Rows[e.RowIndex];
                txtMaPhieuNhap.Text = selectedRow.Cells["MAPHIEUNHAP"].Value.ToString();
                txtNgayNhap.Text = ((DateTime)selectedRow.Cells["NGAYNHAP"].Value).ToString("yyyy-MM-dd");

                // Nếu có thêm cột mã sách và số lượng thì có thể thêm vào đây
                txtPNmasacch.Text = selectedRow.Cells["MASACH"].Value.ToString();
                txtPNsl.Text = selectedRow.Cells["SOLUONG"].Value.ToString();
            }
        }


        private void btntlthem_Click(object sender, EventArgs e)
        {
            var theLoai = new THELOAISACH
            {
                MATHELOAISACH = int.Parse(txtMaTheLoai.Text), // Assume user inputs valid ID
                TENTHELOAISACH = txtTenTheLoai.Text
            };

            var service = new TheLoaiService();
            service.AddTheLoai(theLoai);
            LoadDataTHELOAI(); // Refresh data
        }

        private void btntlxoa_Click(object sender, EventArgs e)
        {
            int maTheLoai = int.Parse(txtMaTheLoai.Text);

            var service = new TheLoaiService();
            service.DeleteTheLoai(maTheLoai);
            LoadDataTHELOAI(); // Refresh data
        }

        private void btntlsua_Click(object sender, EventArgs e)
        {
            var theLoai = new THELOAISACH
            {
                MATHELOAISACH = int.Parse(txtMaTheLoai.Text),
                TENTHELOAISACH = txtTenTheLoai.Text
            };

            var service = new TheLoaiService();
            service.UpdateTheLoai(theLoai);
            LoadDataTHELOAI(); // Refresh data
        }

        private void dgvTheloai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvTheloai.Rows[e.RowIndex];
                txtMaTheLoai.Text = selectedRow.Cells["MATHELOAISACH"].Value.ToString();
                txtTenTheLoai.Text = selectedRow.Cells["TENTHELOAISACH"].Value.ToString();
            }
        }
        private void LoadDataHoaDon()
        {
            var service = new CT_HoaDonService();
            var data = service.GetAllCT_HoaDon();

            var dataTable = new DataTable();
            dataTable.Columns.Add("MAHOADON", typeof(int));
            dataTable.Columns.Add("NGAYLAP", typeof(DateTime));
            dataTable.Columns.Add("MASACH", typeof(int));
            dataTable.Columns.Add("SOLUONG", typeof(int));
            dataTable.Columns.Add("TONGTIEN", typeof(int));


            foreach (var item in data)
            {
                dataTable.Rows.Add(item.MAHD, item.NGAYLAP, item.MASACH, item.SOLUONG, item.TONGTIEN);
            }

            dgvHoaDon.DataSource = dataTable;

        }

        private void btnhdthem_Click(object sender, EventArgs e)
        {
            var hoaDon = new CT_HOADON
            {
                MAHD = int.Parse(txtMaHoaDon.Text), // Assume user inputs valid ID
                NGAYLAP = DateTime.Parse(txtNgayLap.Text),
                TONGTIEN = int.Parse(txtHDtt.Text),
                MASACH = int.Parse(txtHDmasach.Text),
                SOLUONG = int.Parse(txtHDsl.Text)
            };

            var service = new CT_HoaDonService();
            service.Add(hoaDon);
            LoadDataHoaDon(); // Refresh data
        }

        private void btnhdsua_Click(object sender, EventArgs e)
        {
            var hoaDon = new HOADON
            {
                MAHD = int.Parse(txtMaHoaDon.Text),
                NGAYLAPHD = DateTime.Parse(txtNgayLap.Text),
                TENKH = txtHDmasach.Text,
                MANV = int.Parse(txtHDtt.Text)
            };

            var service = new HoaDonService();
            service.UpdateHoaDon(hoaDon);
            LoadDataHoaDon(); // Refresh data
        }

        private void btnhdxoa_Click(object sender, EventArgs e)
        {

            
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvHoaDon.Rows[e.RowIndex];
                txtMaHoaDon.Text = selectedRow.Cells["MAHOADON"].Value.ToString();
                txtNgayLap.Text = ((DateTime)selectedRow.Cells["NGAYLAP"].Value).ToString("yyyy-MM-dd");
                txtHDmasach.Text = selectedRow.Cells["MASACH"].Value.ToString();
                txtHDtt.Text = selectedRow.Cells["TONGTIEN"].Value.ToString();
                txtHDsl.Text = selectedRow.Cells["SOLUONG"].Value.ToString();
            }
        }



        private void LoadNhanVien()
        {
            var service = new NhanVienService();  // Khởi tạo dịch vụ nhân viên
            var data = service.GetAllNhanViens(); // Lấy danh sách nhân viên

            // Giả sử bạn có một DataGridView tên là dgvNhanVien
            dgvNhanVien.DataSource = data; // Gán danh sách nhân viên cho DataGridView

            var dataTable = new DataTable();
            dataTable.Columns.Add("MANHANVIEN", typeof(string));
            dataTable.Columns.Add("TENNHANVIEN", typeof(string));
            dataTable.Columns.Add("DIACHI", typeof(string));
            dataTable.Columns.Add("SODIENTHOAI", typeof(int));
            dataTable.Columns.Add("EMAIL", typeof(string));


            foreach (var item in data)
            {
                dataTable.Rows.Add(item.MANV, item.TENNV, item.DIACHI, item.SDT, item.EMAIL);
            }

            dgvNhanVien.DataSource = dataTable;
        }

        private void btnthemnv_Click(object sender, EventArgs e)
        {
            try
            {
                var nhanVien = new NHANVIEN
                {
                    MANV = int.Parse(txtMaNV.Text),
                    TENNV = txtTenNV.Text,
                    DIACHI = txtDiaChi.Text,
                    SDT = txtsdtnv.Text,
                    EMAIL = txtEmail.Text
                };

                var service = new NhanVienService();
                service.AddNhanVien(nhanVien);
                MessageBox.Show("Nhân viên đã được thêm!");
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi
            }
        }

        private void btnsuanv_Click(object sender, EventArgs e)
        {
            try
            {
                var nhanVien = new NHANVIEN
                {
                    MANV = int.Parse(txtMaNV.Text),
                    TENNV = txtTenNV.Text,
                    DIACHI = txtDiaChi.Text,
                    SDT = txtsdtnv.Text,
                    EMAIL = txtEmail.Text
                };

                var service = new NhanVienService();
                service.UpdateNhanVien(nhanVien);
                MessageBox.Show("Nhân viên đã được cập nhật!");
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi
            }
        }

        private void btnxoanv_Click(object sender, EventArgs e)
        {
            try
            {
                int maNV = int.Parse(txtMaNV.Text);
                var service = new NhanVienService();
                service.RemoveNhanVien(maNV);
                MessageBox.Show("Nhân viên đã được xóa!");
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi
            }
        }


        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng được chọn là hợp lệ
            {
                var selectedRow = dgvNhanVien.Rows[e.RowIndex]; // Lấy hàng được chọn

                // Sử dụng kiểm tra null trước khi gán
                txtMaNV.Text = selectedRow.Cells["MANHANVIEN"].Value.ToString();
                txtTenNV.Text = selectedRow.Cells["TENNHANVIEN"].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells["DIACHI"].Value.ToString();
                txtsdtnv.Text = selectedRow.Cells["SODIENTHOAI"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["EMAIL"].Value.ToString();
            }
        }
        private void LoadLuong()
        {
            var service = new LuongService();
            var data = service.GetAllLuongs();


            dgvLuong.DataSource = data;// Gán danh sách nhân viên cho DataGridView

            var dataTable = new DataTable();
            dataTable.Columns.Add("MAPHIEULUONG", typeof(int));
            dataTable.Columns.Add("MANHANVIEN", typeof(int));
             dataTable.Columns.Add("TENNHANVIEN", typeof(string));
            dataTable.Columns.Add("LUONGTHANG", typeof(int));


            foreach (var item in data)
            {
                dataTable.Rows.Add(item.MALUONG, item.MANV, item.TENNV, item.LUONGTHANG);
            }

            dgvLuong.DataSource = dataTable;
        }

        private void btnluongthem_Click(object sender, EventArgs e)
        {
            try
            {
                var luong = new LUONG
                {
                    MALUONG = int.Parse(txtMaPhieuLuong.Text),
                    MANV = int.Parse(txtLuongMANV.Text), // Lấy từ combobox hoặc textbox
                    TENNV = txtLtennv.Text,
                    LUONGTHANG = int.Parse(txtLuongThang.Text),

                };

                var service = new LuongService();
                service.AddLuong(luong);
                MessageBox.Show("Lương đã được thêm!");
                LoadLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnluongsua_Click(object sender, EventArgs e)
        {
            try
            {
                var luong = new LUONG
                {
                    MALUONG = int.Parse(txtMaPhieuLuong.Text),
                    MANV = int.Parse(txtLuongMANV.Text),
                    TENNV = txtLtennv.Text,
                    LUONGTHANG = double.Parse(txtLuongThang.Text),
                };

                var service = new LuongService();
                service.UpdateLuong(luong);
                MessageBox.Show("Lương đã được cập nhật!");
                LoadLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnluongxoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maLuong = int.Parse(txtMaPhieuLuong.Text);
                var service = new LuongService();
                service.RemoveLuong(maLuong);
                MessageBox.Show("Lương đã được xóa!");
                LoadLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvLuong.Rows[e.RowIndex];
                txtMaPhieuLuong.Text = selectedRow.Cells["MAPHIEULUONG"].Value.ToString();
                txtLuongMANV.Text = selectedRow.Cells["MANHANVIEN"].Value.ToString();
                txtLtennv.Text = selectedRow.Cells["TENNHANVIEN"].Value.ToString();
                txtLuongThang.Text = selectedRow.Cells["LUONGTHANG"].Value.ToString();

            }
        }
        public SACH TimSach(int maSach)
        {
            using (var context = new BansachModel())
            {
                // Tìm sách theo mã sách
                return context.SACH.FirstOrDefault(s => s.MASACH == maSach);
            }
        }
        private void btntim_Click(object sender, EventArgs e)
        {
            // Lấy mã sách từ TextBox
            int maSach = int.Parse(txtMaSach.Text);

            // Gọi phương thức tìm sách
            var sach = TimSach(maSach);

            // Kiểm tra nếu sách tồn tại
            if (sach != null)
            {
                // Hiển thị thông tin sách lên các TextBox (hoặc điều khiển khác)
                txttensach.Text = sach.TENSACH;
                txtloaisach.Text = sach.MATHELOAISACH.ToString();
                txttacgia.Text = sach.TACGIA;
                txtSoLuong.Text = sach.SL.ToString();
                txtGiaBan.Text = sach.GIA.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách với mã: " + maSach);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TinhTongTien();
            THANHTOAN F = new THANHTOAN();
            this.Hide();
            F.ShowDialog();
            this.Show();
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void TinhTongTien()
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadDataSACH();
            LoadDataTHELOAI();
            LoadDataPhieuNhap();
            LoadDataHoaDon();
            LoadNhanVien();
            LoadLuong();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadDataSACH();
            LoadDataTHELOAI();
            LoadDataPhieuNhap();
            LoadDataHoaDon();
            LoadNhanVien();
            LoadLuong();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

