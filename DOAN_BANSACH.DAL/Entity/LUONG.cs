namespace DOAN_BANSACH.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("LUONG")]
    public partial class LUONG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MALUONG { get; set; }

        public int? MANV { get; set; }

        public int? THANG { get; set; }

        public int? NAM { get; set; }

        public double? LUONGTHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
    public class LuongRepository
    {
        public List<LUONG> GetAll()
        {
            using (var context = new BansachModel())
            {
                return context.LUONG.ToList();
            }
        }

        public void Add(LUONG luong)
        {
            using (var context = new BansachModel())
            {
                context.LUONG.Add(luong);
                context.SaveChanges();
            }
        }

        public void Update(LUONG luong)
        {
            using (var context = new BansachModel())
            {
                var existing = context.LUONG.Find(luong.MALUONG);
                if (existing != null)
                {
                    existing.MANV = luong.MANV;
                    existing.LUONGTHANG = luong.LUONGTHANG;
                 //   existing.NGAYTHANG = luong.NGAYTHANG;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Lýõng không t?n t?i!");
                }
            }
        }

        public void Delete(int maLuong)
        {
            using (var context = new BansachModel())
            {
                var luong = context.LUONG.Find(maLuong);
                if (luong != null)
                {
                    context.LUONG.Remove(luong);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Lýõng không t?n t?i!");
                }
            }
        }

    }

}
