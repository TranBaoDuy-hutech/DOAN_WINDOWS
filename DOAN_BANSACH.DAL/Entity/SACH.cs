namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CT_HOADON = new HashSet<CT_HOADON>();
            CT_PHIEUNHAP = new HashSet<CT_PHIEUNHAP>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        [StringLength(255)]
        public string TENSACH { get; set; }

        public int? MATHELOAISACH { get; set; }
        public string TENTHELOAI {  get; set; }

        [StringLength(255)]
        public string TACGIA { get; set; }

        public int? SL { get; set; }

        public decimal? GIA { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }

        public virtual THELOAISACH THELOAISACH { get; set; }

    }
    public class SachRepository
    {
        public List<SACH> GetAllSACH()
        {
            using (var context = new BansachModel())
            {
                return context.SACH.ToList();
            }
        }

        public void AddSach(SACH sach)
        {
            using (var context = new BansachModel())
            {
                context.SACH.Add(sach);
                context.SaveChanges();
            }
        }

        public void EditSach(SACH sach)
        {
            using (var context = new BansachModel())
            {
                var existingSach = context.SACH.FirstOrDefault(s => s.MASACH == sach.MASACH);
                if (existingSach != null)
                {
                    existingSach.TENSACH = sach.TENSACH;
                    existingSach.TENTHELOAI = sach.TENTHELOAI;
                    existingSach.TACGIA = sach.TACGIA;
                    existingSach.SL = sach.SL;
                    existingSach.GIA = sach.GIA;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteSach(int maSach)
        {
            using (var context = new BansachModel())
            {
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                if (sach != null)
                {
                    context.SACH.Remove(sach);
                    context.SaveChanges();
                }
            }
        }
        public void DeductStockAfterPayment(int maSach, int quantitySold)
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
        public bool CheckStockAvailability(int maSach, int quantitySold)
        {
            using (var context = new BansachModel())
            {
                var sach = context.SACH.FirstOrDefault(s => s.MASACH == maSach);
                return sach != null && sach.SL >= quantitySold; // Trả về true nếu đủ hàng
            }
        }



    }
}