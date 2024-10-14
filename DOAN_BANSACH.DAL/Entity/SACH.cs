namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
}
