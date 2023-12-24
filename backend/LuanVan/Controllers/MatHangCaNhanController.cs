using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatHangCaNhanController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MatHangCaNhanController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<MatHangCaNhanController>
        [HttpGet]
        public IActionResult Get(string filter = "", int page = 1, int limit = 5, string id = "")
        {
            var list = new List<MatHangCaNhan>();
            if (filter != "")
            {
                list = _context.MatHangCaNhans.Include(m=>m.TaiKhoan).Include(m => m.LoaiMatHang).Include(m=>m.TaiKhoan).Where(m => m.MaTaiKhoan == id && (m.TenMatHangCaNhan.Contains(filter)
                || m.TrongLuong.ToString().Contains(filter)
                || m.ChieuCao.ToString().Contains(filter)
                || m.ChieuRong.ToString().Contains(filter)
                || m.ChieuDai.ToString().Contains(filter))
            )

                    .ToList();

            }
            else { list = _context.MatHangCaNhans.Include(m=>m.TaiKhoan).Include(m => m.LoaiMatHang).Where(m => m.MaTaiKhoan == id).ToList(); }
            var data = PaginatedList<MatHangCaNhan>.Create(list, page, limit);

            return Ok(new
            {
                data = data,
                totalPage = data.TotalPage,
                totalRecord = list.Count
            });
        }

        // GET api/<MatHangCaNhanController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_context.MatHangCaNhans.Where(m => m.MaTaiKhoan == id && m.Duyet==true).ToList());
        }

        // POST api/<MatHangCaNhanController>
        [HttpPost]
        public IActionResult Post(MatHangCaNhan newRecord)
        {
            if (_context.MatHangCaNhans.Where(m => m.MaTaiKhoan == newRecord.MaTaiKhoan
             && m.TenMatHangCaNhan == newRecord.TenMatHangCaNhan && m.MaMatHangCaNhan != newRecord.MaMatHangCaNhan && m.MaLoaiMatHang == newRecord.MaLoaiMatHang
            ).Any())
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Messgae = "Mặt hàng đã tồn tại",
                    Result = false
                });
            }
            else
            {

                _context.MatHangCaNhans.Add(newRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Messgae = "Đã thêm mặt hàng, công ty sẽ cử người đến xác nhận và duyệt sau đó",
                    Result = true
                });
            }
        }

        // PUT api/<MatHangCaNhanController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, MatHangCaNhan updateRecord)
        {
            if (_context.MatHangCaNhans.Where(m => m.MaTaiKhoan == updateRecord.MaTaiKhoan
              && m.TenMatHangCaNhan == updateRecord.TenMatHangCaNhan && m.MaMatHangCaNhan != updateRecord.MaMatHangCaNhan && m.MaLoaiMatHang == updateRecord.MaLoaiMatHang
             ).Any())
            {
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Messgae = "Mặt hàng đã tồn tại",
                    Result = false
                });
            }
            else
            {
                updateRecord.Duyet = false;
                _context.MatHangCaNhans.Update(updateRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Data = null,
                    Messgae = "Đã cập nhật mặt hàng, công ty sẽ cử người đến xác nhận và duyệt sau đó",
                    Result = true
                });
            }
        }

        [HttpGet("quanly")]
        public IActionResult GetQL()
        {
            return Ok(_context.MatHangCaNhans.Include(m=>m.LoaiMatHang).Where(m=>m.Duyet == false).ToList().Select(m=> new{
                m.MaMatHangCaNhan,
                m.NgayDuyet,
                m.Duyet,
                m.TenMatHangCaNhan,
                m.GiaTri,
                m.ChieuCao,
                m.ChieuDai,
                m.ChieuRong,
                m.MaLoaiMatHang,
                m.TrongLuong,
                m.MaTaiKhoan,
                m.LoaiMatHang.TenLoaiMatHang,
                daDuyetTD = m.NgayDuyet != null && m.Duyet == false ? true : false,
            }));
        }
        [HttpPut("quanly/{id}")]
        public IActionResult PutQL(int id,MatHangCaNhan matHangCaNhan)
        {
            if (id == 0)
            {
                matHangCaNhan.Duyet = false;
            }
            else
            {
                matHangCaNhan.Duyet = true;
            }
            matHangCaNhan.NgayDuyet = DateTime.Now;
            _context.MatHangCaNhans.Update(matHangCaNhan);
            _context.SaveChanges();
            return Ok(true);
        }
        [HttpGet("getMatHang/{id}")]
        public IActionResult GetMatHang(int id,string tk)
        {
            return Ok(_context.MatHangCaNhans.Where(m => m.MaLoaiMatHang == id && m.MaTaiKhoan == tk && m.Duyet == true).ToList());
        }

        // DELETE api/<MatHangCaNhanController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.MatHangCaNhans.Remove(_context.MatHangCaNhans.Find(id));
            _context.SaveChanges();
            return Ok(true);
        }
    }
}
