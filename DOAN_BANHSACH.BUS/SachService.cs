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
                private readonly SachRepository _sachRepository;

                public SachService()
                {
                    _sachRepository = new SachRepository();
                }

                public List<SACH> GetAllSACH()
                {
                    return _sachRepository.GetAllSACH();
                }

                public void AddSach(int maSach, string tenSach, string theLoai, string tacGia, int soLuong, decimal giaBan)
                {
                    var sach = new SACH
                    {
                        MASACH = maSach,
                        TENSACH = tenSach,
                        TENTHELOAI = theLoai,
                        TACGIA = tacGia,
                        SL = soLuong,
                        GIA = giaBan
                    };
                    _sachRepository.AddSach(sach);
                }

                public void EditSach(int maSach, string tenSach, string theLoai, string tacGia, int soLuong, decimal giaBan)
                {
                    var sach = new SACH
                    {
                        MASACH = maSach,
                        TENSACH = tenSach,
                        TENTHELOAI = theLoai,
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
