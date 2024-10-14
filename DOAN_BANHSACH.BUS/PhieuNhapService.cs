using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class PhieuNhapService
    {
        private readonly PhieuNhapRepository _repository;

        public PhieuNhapService()
        {
            _repository = new PhieuNhapRepository();
        }

        public List<PHIEUNHAP> GetAllPhieuNhap()
        {
            return _repository.GetAll();
        }

        public void AddPhieuNhap(PHIEUNHAP phieuNhap)
        {
            _repository.Add(phieuNhap);
        }

        public void UpdatePhieuNhap(PHIEUNHAP phieuNhap)
        {
            _repository.Update(phieuNhap);
        }

        public void DeletePhieuNhap(int maPhieuNhap)
        {
            _repository.Delete(maPhieuNhap);
        }
    }

}
