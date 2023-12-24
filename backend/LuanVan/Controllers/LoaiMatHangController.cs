using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiMatHangController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaiMatHangController(MyDbContext context)
        {
            _context = context; 
        }
        // GET: api/<LoaiMatHangController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.LoaiMatHangs.ToList());
        }

        // GET api/<LoaiMatHangController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.LoaiMatHangs.Find(id));
        }

        // POST api/<LoaiMatHangController>
        [HttpPost]
        public IActionResult Post(LoaiMatHang loaiMatHang)
        {
            if (_context.LoaiMatHangs.Where(m=>m.TenLoaiMatHang == loaiMatHang.TenLoaiMatHang).Any())
            {
                return Ok(false);
            }
            else
            {
                
                _context.LoaiMatHangs.Add(loaiMatHang);
                _context.SaveChanges();
                return Ok(true);
            }

        }

        // PUT api/<LoaiMatHangController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,  LoaiMatHang loaiMatHang)
        {
            if (_context.LoaiMatHangs.Where(m => m.TenLoaiMatHang == loaiMatHang.TenLoaiMatHang && m.MaLoaiMatHang != id).Any())
            {
                return Ok(false);
            }
            else
            {                
                _context.LoaiMatHangs.Update(loaiMatHang);
                _context.SaveChanges();
                return Ok(true);
            }
        }

        // DELETE api/<LoaiMatHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
