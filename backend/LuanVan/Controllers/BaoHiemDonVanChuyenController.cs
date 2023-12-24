using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoHiemDonVanChuyenController : ControllerBase
    {
        private readonly MyDbContext _context;

        public BaoHiemDonVanChuyenController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<BaoHiemDonVanChuyenController>
        [HttpGet]
        public IEnumerable<BaoHiemDonVanChuyen> Get()
        {
            return _context.BaoHiemDonVanChuyens.ToList();
        }

        // GET api/<BaoHiemDonVanChuyenController>/5
        [HttpGet("baohiem")]
        public BaoHiemDonVanChuyen GetID(float tong)
        {
            return _context.BaoHiemDonVanChuyens.Where(m=>m.GiaTriBatDau <= tong && m.GiaTriKetThuc >= tong).SingleOrDefault();
        }
        [HttpGet("getMax")]
        public BaoHiemDonVanChuyen Getmax()
        {
            return _context.BaoHiemDonVanChuyens.OrderByDescending(m=>m.GiaTriKetThuc).First();
        }

        // POST api/<BaoHiemDonVanChuyenController>
        [HttpPost]
        public IActionResult Post(BaoHiemDonVanChuyen baoHiemDonVanChuyen)
        {
            var TrongLuong = _context.BaoHiemDonVanChuyens.ToList();
            var result = true;
            var b = baoHiemDonVanChuyen.GiaTriBatDau;
            var c = baoHiemDonVanChuyen.GiaTriKetThuc;
            if (TrongLuong.Count > 0)
            {


                foreach (var m in TrongLuong)
                {
                    var a = m.GiaTriBatDau;
                    var d = m.GiaTriKetThuc;
                    if (b > d) { result = true; }
                    else if (d == c && b > a) { result = true; }
                    if (
                        (b >= a && b <= d && c >= a && c <= d) ||
                        (b <= a && d >= a) ||
                        (c >= d && b <= c) ||
                        (c == d && b == a)
                        )
                    {
                        result = false;
                    }
                }
            }
            if (result)
            {
                _context.BaoHiemDonVanChuyens.Add(baoHiemDonVanChuyen);
                _context.SaveChanges();
            }
            return Ok(result);
        }

        // PUT api/<BaoHiemDonVanChuyenController>/5
        [HttpPut]
        public IActionResult Put(BaoHiemDonVanChuyen baoHiemDonVanChuyen)
        {
            var TrongLuong = _context.BaoHiemDonVanChuyens.Where(m=>m.MaBaoHiemDonVanChuyen != baoHiemDonVanChuyen.MaBaoHiemDonVanChuyen).ToList();
            var result = true;
            if (TrongLuong.Count > 0)
            {
                foreach (var m in TrongLuong)
                {
                    if (m.GiaTriBatDau > baoHiemDonVanChuyen.GiaTriKetThuc || m.GiaTriKetThuc < baoHiemDonVanChuyen.GiaTriBatDau)
                        result = true;
                   else result = false;
                }
            }
            if (result)
            {
                _context.BaoHiemDonVanChuyens.Update(baoHiemDonVanChuyen);
                _context.SaveChanges();
            }
            return Ok(result);
        }

        // DELETE api/<BaoHiemDonVanChuyenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
