namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CT_HOADON = new HashSet<CT_HOADON>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYLAPHD { get; set; }

        [StringLength(255)]
        public string TENKH { get; set; }

        [StringLength(15)]
        public string SDTKH { get; set; }

        public int? MANV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection <CT_HOADON> CT_HOADON { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
    public class HoaDonRepository
    {
        public List<HOADON> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.HOADON.ToList();
            }
        }

        public void Add(HOADON hoaDon)
        {
            using (var context = new BansachModel())
            {
                context.HOADON.Add(hoaDon);
                context.SaveChanges();
            }
        }

        public void Update(HOADON hoaDon)
        {
            using (var context = new BansachModel())
            {
                var existing = context.HOADON.Find(hoaDon.MAHD);
                if (existing != null)
                {
                    existing.NGAYLAPHD = hoaDon.NGAYLAPHD;
                    existing.TENKH = hoaDon.TENKH;
                    existing.SDTKH = hoaDon.SDTKH; // Ð?m b?o c?t này t?n t?i
                    existing.MANV = hoaDon.MANV;

                    // Ki?m tra xem NHANVIEN có null hay không
                    if (hoaDon.NHANVIEN != null)
                    {
                        existing.NHANVIEN = hoaDon.NHANVIEN;
                    }

                    context.SaveChanges();
                }
            }
        }


        public void Delete(int maHoaDon)
        {
            using (var context = new BansachModel())
            {
                var hoaDon = context.HOADON.Find(maHoaDon);
                if (hoaDon != null)
                {
                    context.HOADON.Remove(hoaDon);
                    context.SaveChanges();
                }
            }
        }
    }

}
