using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class HoaDonService
    {
        private readonly HoaDonRepository _repository;

        public HoaDonService()
        {
            _repository = new HoaDonRepository();
        }

        public List<HOADON> GetAllHoaDon()
        {
            return _repository.GetAll();
        }

        public void AddHoaDon(HOADON hoaDon)
        {
            _repository.Add(hoaDon);
        }

        public void UpdateHoaDon(HOADON hoaDon)
        {
            _repository.Update(hoaDon);
        }

        public void DeleteHoaDon(int maHoaDon)
        {
            _repository.Delete(maHoaDon);
        }
    }

}
