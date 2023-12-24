
using Azure.Core;
using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LuanVan.Service
{
    public class HinhThucVanChuyenRepository : IHinhThucVanChuyenRepository
    {
        private readonly MyDbContext _context;

        public HinhThucVanChuyenRepository(MyDbContext context) {
            _context = context;
        }

        public async Task<HinhThucVanChuyen> Add(HinhThucVanChuyen hinhThucVanChuyen)
        {
            _context.HinhThucVanChuyens.AddAsync(hinhThucVanChuyen);
            await _context.SaveChangesAsync();
            return hinhThucVanChuyen;
        }

        public async Task<Boolean> Delete(int id)
        {
            if (_context.CuocPhis.FirstOrDefault(m => m.MaHinhThucVanChuyen == id) != null)
                return false;
            var DeleteBook = await _context.HinhThucVanChuyens.SingleOrDefaultAsync(n => n.HinhThucVanCHuyenId == id);
            if (DeleteBook != null)
            {
                _context.HinhThucVanChuyens!.Remove(DeleteBook);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<int> Count()
        {
            return  _context.HinhThucVanChuyens.Count();
        }
        public async Task<List<HinhThucVanChuyen>> GetAll(string filter)
        {
         if (filter=="")
                return await _context.HinhThucVanChuyens.ToListAsync();
            return await _context.HinhThucVanChuyens.Where(m=>m.Ten.Contains(filter)).ToListAsync();
        }

        public async Task<HinhThucVanChuyen> GetById(int id)
        {
            var HinhThucVanChuyen =await _context.HinhThucVanChuyens!.FindAsync(id);
           
            return HinhThucVanChuyen;
        }

        public async Task<HinhThucVanChuyen> UpDate(HinhThucVanChuyen hinhThucVanChuyen)
        {
                _context.HinhThucVanChuyens.Update(hinhThucVanChuyen);
                await _context.SaveChangesAsync();
                return hinhThucVanChuyen;

        }

        public async Task<Boolean> CheckDelete(int id)
        {
            var result = true;
            var obj = await _context.CuocPhis.SingleOrDefaultAsync(m=>m.MaHinhThucVanChuyen==id);
            if ( obj != null)
                result = false;
            return  result;
        }
    }
}
