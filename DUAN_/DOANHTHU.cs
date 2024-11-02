using DOAN_BANHSACH.BUS;
using DOAN_BANSACH.DAL.Entity;
using OfficeOpenXml;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUAN_
{
    public partial class DOANHTHU : Form
    {
        public DOANHTHU()
        {
            InitializeComponent();          
        }

        private void DOANHTHU_Load(object sender, EventArgs e)
        {          
        //    dataNgay.Value = DateTime.Now;          
            LoadDataCT_HoaDon();
            dataNgay.Value = DateTime.Now;
        }
       
        private void CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;

            foreach (DataGridViewRow row in dgvct_hd.Rows)
            {
                if (row.Cells["TONGTIEN"].Value != null)
                {
                    totalRevenue += Convert.ToDecimal(row.Cells["TONGTIEN"].Value);
                }
            }

            txtdthu.Text = totalRevenue.ToString("N0"); // Hiển thị tổng doanh thu khi form load
        }
       


        private void LoadDataCT_HoaDon()
        {
            var service = new CT_HoaDonService();
            var data = service.GetAllCT_HoaDon();

            var dataTable = new DataTable();
            dataTable.Columns.Add("MAHD", typeof(int));
            dataTable.Columns.Add("NGAYLAP", typeof(DateTime));
            dataTable.Columns.Add("MASACH", typeof(int));
            dataTable.Columns.Add("SOLUONG" , typeof(int));
            dataTable.Columns.Add("TONGTIEN", typeof(int));
            dataTable.Columns.Add("TIENNHAN", typeof(int));
            dataTable.Columns.Add("TIENTHUA", typeof(int));

            foreach (var item in data)
            {
                dataTable.Rows.Add( item.MAHD,item.NGAYLAP, item.MASACH,item.SOLUONG, item.TONGTIEN, item.TIENNHAN, item.TIENTHUA);
            }
            dgvct_hd.DataSource = dataTable;

        }
        private void CalculateTotalRevenueByDate()
        {
            // Dictionary để lưu trữ tổng doanh thu theo từng ngày
            Dictionary<string, decimal> revenueByDate = new Dictionary<string, decimal>();

            // Duyệt qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in dgvct_hd.Rows)
            {
                // Kiểm tra nếu ô ngày lập và tổng tiền không rỗng
                if (row.Cells["NGAYLAP"].Value != null && row.Cells[4].Value != null)
                {
                    // Lấy ngày lập và chuyển về dạng chuỗi theo định dạng "dd/MM/yyyy"
                    string ngayLap = Convert.ToDateTime(row.Cells["NGAYLAP"].Value).ToString("dd/MM/yyyy");

                    // Lấy tổng tiền
                    decimal tongTien = Convert.ToDecimal(row.Cells[4].Value);

                    // Tính tổng doanh thu theo ngày
                    if (revenueByDate.ContainsKey(ngayLap))
                    {
                        revenueByDate[ngayLap] += tongTien;
                    }
                    else
                    {
                        revenueByDate[ngayLap] = tongTien;
                    }
                }
            }

            // Hiển thị tổng doanh thu cho từng ngày
            string message = "Doanh thu theo từng ngày:\n";
            foreach (var revenue in revenueByDate)
            {
                message += $"Ngày {revenue.Key}: {revenue.Value:N0} VND\n";
            }

            MessageBox.Show(message, "Doanh thu theo ngày", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dataNgay.Value.Date; // Lấy ngày từ DateTimePicker
            CalculateDailyRevenue(); // Tính doanh thu cho ngày đã chọn
            FilterInvoicesByDate(selectedDate); // Lọc hóa đơn theo ngày đã chọn

        }

        private void CalculateDailyRevenue()
        {
            decimal totalRevenue = 0;
            DateTime selectedDate = dataNgay.Value.Date; // Lấy ngày từ DateTimePicker

            // Duyệt qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in dgvct_hd.Rows)
            {
                if (row.Cells["NGAYLAP"].Value != null) // Kiểm tra nếu ô không rỗng
                {
                    DateTime dateRow = DateTime.Parse(row.Cells["NGAYLAP"].Value.ToString()).Date;

                    // Kiểm tra xem ngày trong dòng có bằng ngày hiện tại không
                    if (dateRow == selectedDate)
                    {
                        // Cộng giá trị ở cột doanh thu (giả sử cột doanh thu là cột thứ 4)
                        totalRevenue += Convert.ToDecimal(row.Cells[4].Value);
                    }
                }
            }

            // Gán tổng doanh thu vào TextBox và định dạng kiểu tiền tệ
            txtdthu.Text = totalRevenue.ToString("N0"); // Định dạng không có số thập phân

            // Hiển thị tổng doanh thu dưới dạng thông báo
            MessageBox.Show($"Tổng doanh thu cho ngày {selectedDate:dd/MM/yyyy} là: {totalRevenue:N0}", "Doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FilterInvoicesByDate(DateTime selectedDate)
        {
            // Tạo DataTable để lưu trữ các hóa đơn đã lọc
            DataTable filteredInvoices = new DataTable();

            // Thêm cột vào DataTable theo cấu trúc của DataGridView
            foreach (DataGridViewColumn column in dgvct_hd.Columns)
            {
                filteredInvoices.Columns.Add(column.Name, column.ValueType);
            }

            // Duyệt qua tất cả các dòng trong DataGridView
            foreach (DataGridViewRow row in dgvct_hd.Rows)
            {
                if (row.Cells["NGAYLAP"].Value != null) // Kiểm tra nếu ô không rỗng
                {
                    DateTime dateRow = DateTime.Parse(row.Cells["NGAYLAP"].Value.ToString()).Date;

                    // Kiểm tra xem ngày trong dòng có bằng ngày được chọn không
                    if (dateRow == selectedDate)
                    {
                        // Tạo dòng mới trong DataTable và thêm vào
                        DataRow newRow = filteredInvoices.NewRow();
                        foreach (DataGridViewColumn column in dgvct_hd.Columns)
                        {
                            newRow[column.Name] = row.Cells[column.Name].Value;
                        }
                        filteredInvoices.Rows.Add(newRow);
                    }
                }
            }

            // Cập nhật DataGridView với dữ liệu đã lọc
            dgvtimhd.DataSource = filteredInvoices;

            // Kiểm tra xem có hóa đơn nào được lọc không
            if (filteredInvoices.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào cho ngày đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            CalculateTotalRevenueByDate();
        }

        private void ExportAllInvoices()
        {
            using (var context = new BansachModel()) // Đảm bảo BansachModel là context của bạn
            {
                var allInvoices = context.CT_HOADON.ToList(); // Giả sử CT_HOADON là bảng hóa đơn chi tiết

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất Hóa Đơn";
                    saveFileDialog.FileName = "HoaDon.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = saveFileDialog.FileName;

                        // Đặt chế độ sử dụng EPPlus
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Hoặc Commercial nếu bạn có giấy phép

                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Hóa Đơn");

                            // Đặt tiêu đề cho các cột
                            worksheet.Cells[1, 1].Value = "Mã Hóa Đơn";
                            worksheet.Cells[1, 2].Value = "Ngày Lập ";
                            worksheet.Cells[1, 3].Value = "Mã Sách";
                            worksheet.Cells[1, 4].Value = "Số Lượng";
                            worksheet.Cells[1, 5].Value = "Tổng Tiền";
                            worksheet.Cells[1, 6].Value = "Tiền Nhận";
                            worksheet.Cells[1, 7].Value = "Tiền Thừa";

                            worksheet.Column(1).Width = 10; 
                            worksheet.Column(2).Width = 25; 
                            worksheet.Column(3).Width = 10; 
                            worksheet.Column(4).Width = 10; 
                            worksheet.Column(5).Width = 20; 
                            worksheet.Column(6).Width = 20;
                            worksheet.Column(7).Width = 20;

                            // Duyệt qua danh sách hóa đơn và thêm vào worksheet
                            for (int i = 0; i < allInvoices.Count; i++)
                            {
                                var invoice = allInvoices[i];
                                worksheet.Cells[i + 2, 1].Value = invoice.MAHD; // Mã hóa đơn
                                worksheet.Cells[i + 2, 2].Value = invoice.NGAYLAP; // Mã hóa đơn
                                worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "dd/MM/yyyy"; // Định dạng ngày
                                worksheet.Cells[i + 2, 3].Value = invoice.MASACH; // Mã sách
                                worksheet.Cells[i + 2, 4].Value = invoice.SOLUONG; // Số lượng
                                worksheet.Cells[i + 2, 5].Value = invoice.TONGTIEN; // Tổng tiền
                                worksheet.Cells[i + 2, 6].Value = invoice.TIENNHAN;
                                worksheet.Cells[i + 2, 7].Value = invoice.TIENTHUA;
                            }

                            // Lưu file
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ExportAllInvoices();
        }
        public List<CT_HOADON> FindByMaHD(int maHD)
        {
            using (var context = new BansachModel())
            {
                // Tìm và trả về danh sách hóa đơn có mã MAHD
                return context.CT_HOADON.Where(h => h.MAHD == maHD).ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int maHD;

            // Kiểm tra mã có hợp lệ không
            if (int.TryParse(txtMaHoaDonTim.Text, out maHD))
            {
                var service = new CT_HoaDonService();

                // Gọi phương thức tìm hóa đơn theo mã
                var hoaDonList = FindByMaHD(maHD);

                if (hoaDonList.Any()) // Nếu có kết quả
                {
                    /*
                    // Chuyển đổi danh sách hoaDonList thành danh sách kiểu mới để hiển thị
                    var displayList = hoaDonList.Select(hoaDon => new
                    {
                        hoaDon.MAHD,
                        hoaDon.MASACH,
                        hoaDon.SOLUONG,
                        hoaDon.TONGTIEN,
                        NGAYLAP = hoaDon.NGAYLAP, // Giữ nguyên kiểu DateTime để hiển thị
                // Không cần định dạng tại đây vì sẽ hiển thị dưới dạng DateTime
                // Nếu bạn cần định dạng, bạn có thể thực hiện ở DataGridView
                // hoặc thêm một cột kiểu string.
                // NgayLap = hoaDon.NGAYLAP.ToString("dd/MM/yyyy"),
                        hoaDon.TIENNHAN,
                        hoaDon.TIENTHUA
                    }).ToList();

                    // Thiết lập DataSource cho DataGridView
                    dgvtimhd.DataSource = displayList;

                    // Cài đặt định dạng cho cột ngày lập nếu cần thiết
                    dgvtimhd.Columns["NGAYLAP"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Định dạng ngày tháng
*/


                    // Nhóm hóa đơn theo MAHD
                    var groupedHoaDon = hoaDonList
                        .GroupBy(hd => hd.MAHD)
                        .Select(g => new
                        {
                            MAHD = g.Key,
                            MASACH = g.Count() > 1
                                ? string.Join(Environment.NewLine, g.Select(hd => $"{hd.MASACH} (x{hd.SOLUONG})")) // Gom nhóm mã sách và số lượng nếu có nhiều dòng
                                : g.First().MASACH.ToString(), // Nếu chỉ có một dòng, hiển thị mã sách mà không cần gộp
                            SOLUONG = g.Count() > 1 ? g.Sum(hd => hd.SOLUONG) : g.First().SOLUONG, // Tính tổng số lượng nếu có nhiều dòng, nếu không, giữ nguyên số lượng
                            TONGTIEN = g.FirstOrDefault()?.TONGTIEN ?? 0, // Lấy giá trị dòng đầu tiên của TONGTIEN
                            NGAYLAP = g.FirstOrDefault()?.NGAYLAP?.ToString("dd/MM/yyyy") ?? "N/A", // Định dạng ngày
                            TIENNHAN = g.FirstOrDefault()?.TIENNHAN ?? 0, // Lấy giá trị dòng đầu tiên của TIENNHAN
                            TIENTHUA = g.FirstOrDefault()?.TIENTHUA ?? 0 // Lấy giá trị dòng đầu tiên của TIENTHUA
                        }).ToList();

                    // Thiết lập DataSource cho DataGridView
                    dgvtimhd.DataSource = groupedHoaDon;
                }
                else
                {
                    // Thông báo nếu không tìm thấy
                    MessageBox.Show("Không tìm thấy hóa đơn với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Thông báo nếu mã hóa đơn không hợp lệ
                MessageBox.Show("Vui lòng nhập mã hóa đơn hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvtimhd.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float lineHeight = 20;

            // Tiêu đề cửa hàng
            e.Graphics.DrawString("CỬA HÀNG SÁCH HUTECH.TEM BAODUY", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin + 150, yPos);
            yPos += lineHeight + 20; // Tăng khoảng cách sau tiêu đề

            // Tiêu đề hóa đơn
            e.Graphics.DrawString("HÓA ĐƠN BÁN HÀNG", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin + 150, yPos);
            yPos += lineHeight + 10; // Tăng khoảng cách sau tiêu đề

            // Ngày lập hóa đơn (lấy từ dòng đầu tiên trong DataGridView)
            if (dgvtimhd.Rows.Count > 0)
            {
                string ngayLap = DateTime.Parse(dgvtimhd.Rows[0].Cells["NGAYLAP"].Value.ToString()).ToString("dd/MM/yyyy");
                e.Graphics.DrawString("Ngày lập: " + ngayLap, new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
                yPos += lineHeight + 10; // Tăng khoảng cách sau ngày lập
            }

            string ngayIn = DateTime.Now.ToString("dd/MM/yyyy");
            e.Graphics.DrawString("Ngày in hóa đơn: " + ngayIn, new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
            yPos += lineHeight + 10;
            // Đường kẻ ngang
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += lineHeight;

            // Thêm tiêu đề cột
            e.Graphics.DrawString("Mã HĐ", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString("Mã Sách", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin + 100, yPos);
            e.Graphics.DrawString("Số Lượng", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin + 200, yPos);
            e.Graphics.DrawString("Tổng Tiền", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin + 300, yPos);
            e.Graphics.DrawString("Tiền Nhận", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin + 400, yPos);
            e.Graphics.DrawString("Tiền Thừa", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, leftMargin + 500, yPos);

            yPos += lineHeight;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 30;

            // In các dòng hóa đơn
            foreach (DataGridViewRow row in dgvtimhd.Rows)
            {
                e.Graphics.DrawString(row.Cells["MAHD"].Value.ToString(), new Font("Arial", 12), Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString(row.Cells["MASACH"].Value.ToString(), new Font("Arial", 12), Brushes.Black, leftMargin + 100, yPos);
                e.Graphics.DrawString(row.Cells["SOLUONG"].Value.ToString(), new Font("Arial", 12), Brushes.Black, leftMargin + 200, yPos);
                e.Graphics.DrawString(row.Cells["TONGTIEN"].Value.ToString(), new Font("Arial", 12), Brushes.Black, leftMargin + 300, yPos);
                e.Graphics.DrawString(row.Cells["TIENNHAN"].Value.ToString(), new Font("Arial", 12), Brushes.Black, leftMargin + 400, yPos);
                e.Graphics.DrawString(row.Cells["TIENTHUA"].Value.ToString(), new Font("Arial", 12), Brushes.Black, leftMargin + 500, yPos);

                yPos += lineHeight;
                e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
                yPos += 30;
            }

            // Đường kẻ cuối hóa đơn
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 30;

            // Thêm mã QR với địa chỉ cửa hàng
            string shopAddress = "https://github.com/TranBaoDuy-hutech/DOAN_WINDOWS";
            using (var qrGenerator = new QRCodeGenerator())
            {
                using (var qrCodeData = qrGenerator.CreateQrCode(shopAddress, QRCodeGenerator.ECCLevel.Q))
                {
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(5);
                        e.Graphics.DrawImage(qrCodeImage, leftMargin + 40, yPos);
                    }
                }
            }

            yPos += 250;

            // Thông điệp dưới mã QR
            e.Graphics.DrawString("Quét mã QR để biết địa chỉ cửa hàng nhé!", new Font("Arial", 10), Brushes.Black, leftMargin, yPos);
            yPos += lineHeight;

            // Thông điệp cảm ơn
            e.Graphics.DrawString("Cảm ơn quý khách đã mua hàng!", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, leftMargin + 150, yPos);
        }

        
        

        private void dgvct_hd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số dòng hợp lệ
            {
                DataGridViewRow selectedRow = dgvct_hd.Rows[e.RowIndex];

                // Tạo DataTable chứa dữ liệu của dòng được chọn
                DataTable selectedDataTable = new DataTable();

                // Thêm cột vào DataTable theo cấu trúc của dgvct_hd
                foreach (DataGridViewColumn column in dgvct_hd.Columns)
                {
                    selectedDataTable.Columns.Add(column.Name, column.ValueType);
                }

                // Tạo dòng mới và sao chép dữ liệu từ dòng đã chọn
                DataRow newRow = selectedDataTable.NewRow();
                foreach (DataGridViewColumn column in dgvct_hd.Columns)
                {
                    newRow[column.Name] = selectedRow.Cells[column.Name].Value;
                }
                selectedDataTable.Rows.Add(newRow);

                // Gán DataTable vào DataSource của dgvtimhd
                dgvtimhd.DataSource = selectedDataTable;
            }
        }
    }


}
