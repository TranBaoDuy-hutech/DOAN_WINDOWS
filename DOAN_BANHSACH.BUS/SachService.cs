using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class SachService
    { 
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
                        existingSach.MATHELOAISACH = sach.MATHELOAISACH;
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
            public class SachService
            {
                private readonly SachRepository _sachRepository;

                public SachService()
                {
                    _sachRepository = new SachRepository();
                }

                public List<SACH> GetAllSACH()
                {
                    return _sachRepository.GetAllSACH();
                }

                public void AddSach(int maSach, string tenSach, int theLoai, string tacGia, int soLuong, decimal giaBan)
                {
                    var sach = new SACH
                    {
                        MASACH = maSach,
                        TENSACH = tenSach,
                        MATHELOAISACH = theLoai,
                        TACGIA = tacGia,
                        SL = soLuong,
                        GIA = giaBan
                    };
                    _sachRepository.AddSach(sach);
                }

                public void EditSach(int maSach, string tenSach, int theLoai, string tacGia, int soLuong, decimal giaBan)
                {
                    var sach = new SACH
                    {
                        MASACH = maSach,
                        TENSACH = tenSach,
                        MATHELOAISACH = theLoai,
                        TACGIA = tacGia,
                        SL = soLuong,
                        GIA = giaBan
                    };
                    _sachRepository.EditSach(sach);
                }

                public void DeleteSach(int maSach)
                {
                    _sachRepository.DeleteSach(maSach);
                }
            }
        }
    }
}
