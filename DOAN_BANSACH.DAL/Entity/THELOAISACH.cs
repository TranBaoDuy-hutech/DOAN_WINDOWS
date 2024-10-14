namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("THELOAISACH")]
    public partial class THELOAISACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THELOAISACH()
        {
            SACH = new HashSet<SACH>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MATHELOAISACH { get; set; }

        [StringLength(255)]
        public string TENTHELOAISACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACH { get; set; }
    }
    public class TheLoaiRepository
    {
        public List<THELOAISACH> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.THELOAISACH.ToList();
            }
        }

        public void Add(THELOAISACH theLoai)
        {
            using (var context = new BansachModel())
            {
                context.THELOAISACH.Add(theLoai);
                context.SaveChanges();
            }
        }

        public void Update(THELOAISACH theLoai)
        {
            using (var context = new BansachModel())
            {
                var existing = context.THELOAISACH.Find(theLoai.MATHELOAISACH);
                if (existing != null)
                {
                    existing.TENTHELOAISACH = theLoai.TENTHELOAISACH;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(int maTheLoai)
        {
            using (var context = new BansachModel())
            {
                var theLoai = context.THELOAISACH.Find(maTheLoai);
                if (theLoai != null)
                {
                    context.THELOAISACH.Remove(theLoai);
                    context.SaveChanges();
                }
            }
        }
    }

}
