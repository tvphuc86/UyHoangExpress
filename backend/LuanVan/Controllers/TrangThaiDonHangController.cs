using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangThaiDonHangController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TrangThaiDonHangController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<TrangThaiDonHangController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TrangThaiDonHangs.ToList().Select(m => new
            {
                m.MaTrangThaiDonVanChuyen,
                m.TenTrangThai,
                m.MoTaTrangThai
            }));
        }

        // GET api/<TrangThaiDonHangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TrangThaiDonHangController>
        [HttpPost]
        public TrangThaiDonHang Post(TrangThaiDonHang newRecord)
        {
            _context.TrangThaiDonHangs.Add(newRecord);
            _context.SaveChanges();

            return newRecord;
        }

        // PUT api/<TrangThaiDonHangController>/5
   
        

        // DELETE api/<TrangThaiDonHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
