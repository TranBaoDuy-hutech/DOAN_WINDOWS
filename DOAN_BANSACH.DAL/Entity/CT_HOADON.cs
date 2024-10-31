namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using OfficeOpenXml;
    using System.Linq;

    public partial class CT_HOADON
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int? SOLUONG { get; set; }
        public int? TONGTIEN { get; set; }
        public DateTime? NGAYLAP { get; set; }

        public int? TIENNHAN { get; set; }
        public int? TIENTHUA { get; set; }
        public virtual HOADON HOADON { get; set; }

        public virtual SACH SACH { get; set; }
    }
    public class CT_HoaDonRepository
    {
        public List<CT_HOADON> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.CT_HOADON.ToList();
            }
        }

        public void Add(CT_HOADON hoaDon)

        {
            using (var context = new BansachModel())
            {
                context.CT_HOADON.Add(hoaDon);
                context.SaveChanges();
            }
        }

        public void Update(CT_HOADON hoaDon)
        {
            using (var context = new BansachModel())
            {
                var existing = context.CT_HOADON.Find(hoaDon.MAHD);
                if (existing != null)
                {
                    existing.MAHD = hoaDon.MAHD;
                    existing.MASACH = hoaDon.MASACH;
                    existing.SOLUONG = hoaDon.SOLUONG;       
                    context.SaveChanges();
                }
            }
        }
        public void Delete( int maHD)
        {
            using (var context = new BansachModel())
            {
                // Tìm hóa đơn theo mã hóa đơn
                var hoaDon = context.CT_HOADON.Find(maHD);
                if (hoaDon != null)
                {
                    context.CT_HOADON.Remove(hoaDon); // Xóa hóa đơn
                    context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
        }
        public List<CT_HOADON> FindByMaHD(int maHD)
        {
            using (var context = new BansachModel())
            {
                // Tìm và trả về danh sách hóa đơn có mã MAHD
                return context.CT_HOADON.Where(h => h.MAHD == maHD).ToList();
            }
        }



    }
}
