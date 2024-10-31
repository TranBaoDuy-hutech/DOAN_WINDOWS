using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class LuongService
    {
        private LuongRepository _repository = new LuongRepository();

        public List<LUONG> GetAllLuongs()
        {
            return _repository.GetAll();
        }

        public void AddLuong(LUONG luong)
        {
            _repository.Add(luong);
        }

        public void UpdateLuong(LUONG luong)
        {
            _repository.Update(luong);
        }

        public void RemoveLuong(int maLuong)
        {
            _repository.Delete(maLuong);
        }
        
    }

}
