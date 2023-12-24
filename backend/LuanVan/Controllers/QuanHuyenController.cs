using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanHuyenController : ControllerBase
    {
        private readonly MyDbContext _context;

        public QuanHuyenController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<QuanHuyenController>

        // GET: api/<QuanHuyenController>
        [HttpGet]
        public IEnumerable<QuanHuyen> Get(int id)
        {
            return _context.QuanHuyens.Where(m=>m.MaTinhThanhPho==id).ToList();
        }
        [HttpGet("tinh")]
        public IActionResult GetQuanHuyen(int idTinh , int maTrongLuong, int maHinhThucVanChuyen)
        {
            var maQuanHuyen = _context.ChiTietCuocPhis.Include(m=>m.CuocPhi).Where(m=>m.CuocPhi.MaTrongLuong==maTrongLuong && m.CuocPhi.MaHinhThucVanChuyen==maHinhThucVanChuyen).Select(m => m.MaQuanHuyen).ToArray();
            return Ok( _context.QuanHuyens.Where(m=>m.MaTinhThanhPho==idTinh && maQuanHuyen.Contains(m.MaQuanHuyen) == false).ToList());
        }
        // GET api/<QuanHuyenController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_context.QuanHuyens.Where(m=>m.MaQuanHuyen==id).Include(m=>m.TinhThanhPho).SingleOrDefault());
        }

        // POST api/<QuanHuyenController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuanHuyenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuanHuyenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
