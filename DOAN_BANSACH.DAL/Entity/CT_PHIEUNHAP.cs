namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PHIEUNHAP
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHIEUNHAP { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MASACH { get; set; }

        public int? SOLUONG { get; set; }

        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
