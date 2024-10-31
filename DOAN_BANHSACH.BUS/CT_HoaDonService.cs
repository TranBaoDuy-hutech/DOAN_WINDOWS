using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DOAN_BANHSACH.BUS.SachService;

namespace DOAN_BANHSACH.BUS
{
    public class CT_HoaDonService
    {
        private readonly CT_HoaDonRepository _repository;

        public CT_HoaDonService()
        {
            _repository = new CT_HoaDonRepository();
        }

        public List<CT_HOADON> GetAllCT_HoaDon()
        {
            return _repository.GetAll();
        }
        public void Add(CT_HOADON hoaDon)
        {
            _repository.Add(hoaDon);
        }
        public void FindByMaHD(int maHD)
        {
            _repository.FindByMaHD(maHD);
        }

    }
}
