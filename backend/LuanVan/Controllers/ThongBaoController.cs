using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ThongBaoController(MyDbContext context)
        {
            _context  = context;
        }
        // GET: api/<ThongBaoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ThongBaoController>/5
        [HttpGet("{maTaiKhoan}")]
        public IActionResult Get(string maTaiKhoan)
        {
            return Ok(_context.ThongBaos.Where(m=>m.MaTaiKhoan==maTaiKhoan).OrderByDescending(m=>m.NgayTao).Take(10).ToList());
        }

        // POST api/<ThongBaoController>
        [HttpPost]
        public IActionResult Post(string TieuDe, string NoiDung, string MaTaiKhoan)
        {
            ThongBao thongBao = new ThongBao();
            thongBao.TieuDe = TieuDe;
            thongBao.NoiDung = NoiDung;
            thongBao.MaTaiKhoan = MaTaiKhoan;
            thongBao.NgayTao = DateTime.Now;
            thongBao.DaXem = false;

            _context.ThongBaos.Add(thongBao);
            _context.SaveChanges();
            return Ok(true);
        }
        [HttpPost("quan-ly")]
        public IActionResult PostQuanLy(string TieuDe, string NoiDung)
        {
            var quanLys = _context.TaiKhoans.Where(m => m.VaiTros.Where(m => m.VaiTro.Quyens.Where(m => m.MaQuyen == 1).Any() == true).Any() == true).ToList();
            foreach (var quanLy in quanLys)
            {
                ThongBao thongBao = new ThongBao();
                thongBao.TieuDe = TieuDe;
                thongBao.NoiDung = NoiDung;
                thongBao.MaTaiKhoan = quanLy.MaTaiKhoan;
                thongBao.NgayTao = DateTime.Now;
                thongBao.DaXem = false;

                _context.ThongBaos.Add(thongBao);
            }
           
            _context.SaveChanges();
            return Ok("Đã gửi yêu cầu");
        }
        // PUT api/<ThongBaoController>/5
        [HttpPut("{maTaiKhoan}")]
        public void Put(string maTaiKhoan)
        {
            foreach(var i in _context.ThongBaos.Where(m => m.MaTaiKhoan == maTaiKhoan).OrderByDescending(m => m.NgayTao).Take(10))
            {
                i.DaXem = true;
                _context.ThongBaos.Update(i);
               
            }
            _context.SaveChanges();

        }

        // DELETE api/<ThongBaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
