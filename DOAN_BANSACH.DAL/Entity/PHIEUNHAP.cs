namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PHIEUNHAP")]
    public partial class PHIEUNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAP()
        {
            CT_PHIEUNHAP = new HashSet<CT_PHIEUNHAP>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHIEUNHAP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYNHAP { get; set; }

        [StringLength(255)]
        public string NCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUNHAP> CT_PHIEUNHAP { get; set; }
    }
    public class PhieuNhapRepository
    {
        public List<PHIEUNHAP> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.PHIEUNHAP.ToList();
            }
        }

        public void Add(PHIEUNHAP phieuNhap)
        {
            using (var context = new BansachModel())
            {
                context.PHIEUNHAP.Add(phieuNhap);
                context.SaveChanges();
            }
        }

        public void Update(PHIEUNHAP phieuNhap)
        {
            using (var context = new BansachModel())
            {
                var existing = context.PHIEUNHAP.Find(phieuNhap.MAPHIEUNHAP);
                if (existing != null)
                {
                    existing.NGAYNHAP = phieuNhap.NGAYNHAP;
                    existing.NCC = phieuNhap.NCC;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int maPhieuNhap)
        {
            using (var context = new BansachModel())
            {
                var phieuNhap = context.PHIEUNHAP.Find(maPhieuNhap);
                if (phieuNhap != null)
                {
                    context.PHIEUNHAP.Remove(phieuNhap);
                    context.SaveChanges();
                }
            }
        }
    }

}
