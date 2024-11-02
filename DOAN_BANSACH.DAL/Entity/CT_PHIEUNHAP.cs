namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        public DateTime? NGAYNHAP { get; set; }


        public virtual PHIEUNHAP PHIEUNHAP { get; set; }

        public virtual SACH SACH { get; set; }
    }
    public class CT_PhieuNhapRepository
    {
        public List<CT_PHIEUNHAP> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.CT_PHIEUNHAP.ToList();
            }
        }

        public void Add(CT_PHIEUNHAP phieuNhap)
        {
            using (var context = new BansachModel())
            {
                context.CT_PHIEUNHAP.Add(phieuNhap);
                context.SaveChanges();

                // Tăng số lượng sách trong kho
                var sach = context.SACH.Find(phieuNhap.MASACH);
                if (sach != null)
                {
                    sach.SL += phieuNhap.SOLUONG ?? 0;
                    context.SaveChanges();
                }
            }
        }


        public void Update(CT_PHIEUNHAP phieuNhap)
        {
            using (var context = new BansachModel())
            {
                var existing = context.CT_PHIEUNHAP.Find(phieuNhap.MAPHIEUNHAP, phieuNhap.MASACH);
                if (existing != null)
                {
                    // Tính chênh lệch số lượng
                    int quantityDifference = (phieuNhap.SOLUONG ?? 0) - (existing.SOLUONG ?? 0);

                    // Cập nhật phiếu nhập
                    existing.SOLUONG = phieuNhap.SOLUONG;
                    existing.NGAYNHAP = phieuNhap.NGAYNHAP;
                    context.SaveChanges();

                    // Cập nhật kho sách theo chênh lệch
                    var sach = context.SACH.Find(phieuNhap.MASACH);
                    if (sach != null)
                    {
                        sach.SL += quantityDifference;
                        context.SaveChanges();
                    }
                }
            }
        }

        public void Delete(int maPhieuNhap, int maSach)
        {
            using (var context = new BansachModel())
            {
                var phieuNhap = context.CT_PHIEUNHAP.Find(maPhieuNhap, maSach);
                if (phieuNhap != null)
                {
                    int quantityToDeduct = phieuNhap.SOLUONG ?? 0;

                    context.CT_PHIEUNHAP.Remove(phieuNhap);
                    context.SaveChanges();

                    // Giảm số lượng sách trong kho
                    var sach = context.SACH.Find(maSach);
                    if (sach != null)
                    {
                        sach.SL -= quantityToDeduct;
                        context.SaveChanges();
                    }
                }
            }
        }



    }
}