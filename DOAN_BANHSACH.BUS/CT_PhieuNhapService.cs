using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class CT_PhieuNhapService
    {
        private readonly CT_PhieuNhapRepository _repository;

        public CT_PhieuNhapService()
        {
            _repository = new CT_PhieuNhapRepository();
        }

        public List<CT_PHIEUNHAP> GetAllCT_PHIEUNHAP()
        {
            return _repository.GetAll();
        }

        public void Add(CT_PHIEUNHAP phieuNhap)
        {
            _repository.Add(phieuNhap);
        }

        public void UpdateCTPhieuNhap(CT_PHIEUNHAP phieuNhap)
        {
            _repository.Update(phieuNhap);
        }





        public void Delete(int maPhieuNhap, int maSach)
        {
            _repository.Delete(maPhieuNhap, maSach);
        }

    }
}
