using DOAN_BANSACH.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_BANHSACH.BUS
{
    public class NhanVienService
    {
        private NhanVienRepository repository = new NhanVienRepository();

        public List<NHANVIEN> GetAllNhanViens()
        {
            return repository.GetAll();
        }

        public void AddNhanVien(NHANVIEN nhanVien)
        {
            repository.AddNhanVien(nhanVien);
        }

        public void UpdateNhanVien(NHANVIEN nhanVien)
        {
            repository.UpdateNhanVien(nhanVien);
        }

        public void RemoveNhanVien(int maNhanVien)
        {
            repository.Delete(maNhanVien);
        }
    }
}
    

