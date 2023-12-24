using LuanVan.Model;
using System.Runtime.CompilerServices;

namespace LuanVan.Service
{
    public interface IHinhThucVanChuyenRepository
    {
        public Task<int> Count();
        public Task<List<HinhThucVanChuyen>> GetAll(string filter);
        public Task<HinhThucVanChuyen> GetById(int id);
        public Task<HinhThucVanChuyen> UpDate(HinhThucVanChuyen hinhThucVanChuyen);
        public Task<Boolean> Delete(int id);
        
        public Task<Boolean> CheckDelete(int id);


        public Task<HinhThucVanChuyen> Add(HinhThucVanChuyen hinhThucVanChuyen);

    }
}
