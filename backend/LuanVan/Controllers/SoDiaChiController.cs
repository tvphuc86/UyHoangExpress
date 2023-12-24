using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoDiaChiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SoDiaChiController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<SoDiaChiController>
        [HttpGet]
        public IActionResult Get(int page, int limit,string MaTaiKhoan)
        {
            var list = _context.SoDiaChis.Where(m=>m.MaTaiKhoan==MaTaiKhoan).Include(m => m.XaPhuong.QuanHuyen.TinhThanhPho).Include(m => m.TaiKhoan).ToList();
            var data = PaginatedList<SoDiaChi>.Create(list, page, limit);

            return Ok(new
            {
                data = data,
                totalPage = data.TotalPage,
                totalRecord = list.Count
            });
        }

        // GET api/<SoDiaChiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SoDiaChiController>
        [HttpPost]
        public IActionResult Post(SoDiaChi newRecord)
        {
            if (_context.SoDiaChis.Where(m => m.MaTaiKhoan==newRecord.MaTaiKhoan && ( newRecord.MaXaPhuong == m.MaXaPhuong && m.DiaChi == newRecord.DiaChi)).Any())
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Tên địa chỉ hoặc địa chỉ đã tồn tại"
                });
            else
            {
                _context.SoDiaChis.Add(newRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = newRecord,
                    Messgae = "Đã thêm một địa chỉ"
                });
            }
        }

        // PUT api/<SoDiaChiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,SoDiaChi updateRecord)
        {
             
            if (_context.SoDiaChis.Where(m => m.MaTaiKhoan == updateRecord.MaTaiKhoan && updateRecord.Ten == m.Ten && m.DiaChi == updateRecord.DiaChi && m.MaXaPhuong == updateRecord.MaXaPhuong).SingleOrDefault() !=null)
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Tên địa chỉ hoặc địa chỉ đã tồn tại"
                });
            else
            {

                _context.SoDiaChis.Update(updateRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = updateRecord,
                    Messgae = "Đã cập nhật địa chỉ"
                });
            }
        }

        // DELETE api/<SoDiaChiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.SoDiaChis.Remove(_context.SoDiaChis.Find(id));
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
