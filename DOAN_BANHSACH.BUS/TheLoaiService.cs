using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class TheLoaiService
    {
        private readonly TheLoaiRepository _repository;

        public TheLoaiService()
        {
            _repository = new TheLoaiRepository();
        }

        public List<THELOAISACH> GetAllTheLoai()
        {
            return _repository.GetAll();
        }

        public void AddTheLoai(THELOAISACH theLoai)
        {
            _repository.Add(theLoai);
        }

        public void UpdateTheLoai(THELOAISACH theLoai)
        {
            _repository.Update(theLoai);
        }

        public void DeleteTheLoai(int maTheLoai)
        {
            _repository.Delete(maTheLoai);
        }
    }

}
