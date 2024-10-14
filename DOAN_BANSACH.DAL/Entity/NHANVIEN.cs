namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADON = new HashSet<HOADON>();
            LUONG = new HashSet<LUONG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MANV { get; set; }

        [StringLength(255)]
        public string TENNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(255)]
        public string DIACHI { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUONG> LUONG { get; set; }
    }
    public class NhanVienRepository
    {
        public List<NHANVIEN> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.NHANVIEN.ToList();
            }
        }

        public void AddNhanVien(NHANVIEN nhanVien)
        {
            using (var context = new BansachModel())
            {
                // Ki?m tra xem nhân viên ð? t?n t?i chýa
                var existing = context.NHANVIEN.Find(nhanVien.MANV);
                if (existing != null)
                {
                    throw new Exception("M? nhân viên ð? t?n t?i!");
                }

                context.NHANVIEN.Add(nhanVien);
                context.SaveChanges();
            }
        }

        public void UpdateNhanVien(NHANVIEN nhanVien)
        {
            using (var context = new BansachModel())
            {
                var existing = context.NHANVIEN.Find(nhanVien.MANV);
                if (existing == null)
                {
                    throw new Exception("Nhân viên không t?n t?i!");
                }

                // C?p nh?t thông tin
                existing.TENNV = nhanVien.TENNV;
                existing.DIACHI = nhanVien.DIACHI;
                existing.SDT = nhanVien.SDT;
                existing.EMAIL = nhanVien.EMAIL;
                context.SaveChanges();
            }
        }


        public void Delete(int maNhanVien)
        {
            using (var context = new BansachModel())
            {
                var nhanVien = context.NHANVIEN.Find(maNhanVien);
                if (nhanVien != null)
                {
                    context.NHANVIEN.Remove(nhanVien);
                    context.SaveChanges();
                }
            }
        }
    }
} 
