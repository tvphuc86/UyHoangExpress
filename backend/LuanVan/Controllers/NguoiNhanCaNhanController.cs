using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiNhanCaNhanController : ControllerBase
    {
        private readonly MyDbContext _context;

        public NguoiNhanCaNhanController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<NguoiNhanCaNhanController>
        [HttpGet]
        public IActionResult Get(string filter="", int page=1, int limit = 5, string id="")
        {
            var list = new List<NguoiNhanCaNhan>();
            if (filter != "" )
            {
                list = _context.NguoiNhanCaNhans.Where(m => m.MaTaiKhoan==id &&( m.TenNguoiNhanCaNhan.Contains(filter)
                || m.XaPhuong.TenXaPhuong.Contains(filter)
                || m.XaPhuong.QuanHuyen.TenQuanHuyen.Contains(filter)
                || m.XaPhuong.QuanHuyen.TinhThanhPho.TenTinhThanhPho.Contains(filter))
            )
            .Include(m => m.XaPhuong.QuanHuyen.TinhThanhPho)
                    .ToList();
             
            }
            else { list = _context.NguoiNhanCaNhans.Where(m => m.MaTaiKhoan == id).Include(m => m.XaPhuong.QuanHuyen.TinhThanhPho).ToList(); }
            var data = PaginatedList<NguoiNhanCaNhan>.Create(list, page, limit);

            return Ok(new
            {
                data = data,
                totalPage = data.TotalPage,
                totalRecord = list.Count
            });
        }
        [HttpGet("NguoiNhanCap3")]
        public IActionResult Get3(string filter = "", int page = 1, int limit = 5, int id=0)
        {
            var list = new List<NguoiNhanCap3>();
            if (filter != "")
            {
                list = _context.NguoiNhanCap.Where(m => m.MaNguoiNhan==id && (m.TenNguoiNhanCap3.Contains(filter)
                || m.XaPhuong.TenXaPhuong.Contains(filter)
                || m.XaPhuong.QuanHuyen.TenQuanHuyen.Contains(filter)
                || m.XaPhuong.QuanHuyen.TinhThanhPho.TenTinhThanhPho.Contains(filter))
            )
            .Include(m => m.XaPhuong.QuanHuyen.TinhThanhPho)
                    .ToList();

            }
            else { list = _context.NguoiNhanCap.Where(m => m.MaNguoiNhan == id).Include(m => m.XaPhuong.QuanHuyen.TinhThanhPho).ToList(); }
            var data = PaginatedList<NguoiNhanCap3>.Create(list, page, limit);

            return Ok(new
            {
                data = data,
                totalPage = data.TotalPage,
                totalRecord = list.Count
            });
        }

        // GET api/<NguoiNhanCaNhanController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_context.NguoiNhanCaNhans.Include(m=>m.XaPhuong.QuanHuyen.TinhThanhPho).Where(m=>m.MaTaiKhoan==id).ToList());
        }

        // POST api/<NguoiNhanCaNhanController>
        [HttpPost]
        public IActionResult Post( NguoiNhanCaNhan newRecord)
        {
            if (_context.NguoiNhanCaNhans.Where(m => m.MaTaiKhoan==newRecord.MaTaiKhoan && m.TenNguoiNhanCaNhan==newRecord.TenNguoiNhanCaNhan && (m.MaXaPhuong==m.MaXaPhuong && m.DiaChiNguoiNhanCaNhan == newRecord.DiaChiNguoiNhanCaNhan))
                .Any())
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Địa chỉ đã tồn tại"
                });
            else
            {
                _context.NguoiNhanCaNhans.Add(newRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = newRecord,
                    Messgae = "Đã thêm người nhận"
                });
            }
        }
        [HttpPost("NguoiNhanCap3")]
        public IActionResult Post3(NguoiNhanCap3 newRecord)
        {
            if (_context.NguoiNhanCap.Where(m => m.MaNguoiNhan == newRecord.MaNguoiNhan && m.TenNguoiNhanCap3==newRecord.TenNguoiNhanCap3 && (m.MaXaPhuong == m.MaXaPhuong && m.DiaChiNguoiNhanCap3 == newRecord.DiaChiNguoiNhanCap3))
                .Any())
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Địa chỉ đã tồn tại"
                });
            else
            {
                _context.NguoiNhanCap.Add(newRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = newRecord,
                    Messgae = "Đã thêm người nhận"
                });
            }
        }

        // PUT api/<NguoiNhanCaNhanController>/5
        [HttpPut]
        public IActionResult Put(NguoiNhanCaNhan updateRecord)
        {
            if (_context.NguoiNhanCaNhans.Where(m => m.MaTaiKhoan == updateRecord.MaTaiKhoan  && m.DiaChiNguoiNhanCaNhan == updateRecord.DiaChiNguoiNhanCaNhan && m.MaXaPhuong == updateRecord.MaXaPhuong && m.TenNguoiNhanCaNhan==updateRecord.TenNguoiNhanCaNhan).SingleOrDefault() != null)
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Tên địa chỉ hoặc địa chỉ đã tồn tại"
                });
            else
            {

                _context.NguoiNhanCaNhans.Update(updateRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = updateRecord,
                    Messgae = "Đã cập nhật địa chỉ"
                });
            }
        }
        [HttpPut("NguoiNhanCap3")]
        public IActionResult Put(NguoiNhanCap3 updateRecord)
        {
            if (_context.NguoiNhanCap.Where(m => m.MaNguoiNhan == updateRecord.MaNguoiNhan && m.TenNguoiNhanCap3==updateRecord.TenNguoiNhanCap3 && m.DiaChiNguoiNhanCap3 == updateRecord.DiaChiNguoiNhanCap3 && m.MaXaPhuong == updateRecord.MaXaPhuong).SingleOrDefault() != null)
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Tên địa chỉ hoặc địa chỉ đã tồn tại"
                });
            else
            {

                _context.NguoiNhanCap.Update(updateRecord);
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = updateRecord,
                    Messgae = "Đã cập nhật địa chỉ"
                });
            }
        }

        // DELETE api/<NguoiNhanCaNhanController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var nguoiNhanCap3 = _context.NguoiNhanCap.SingleOrDefault(m=>m.MaNguoiNhan==id);
            if(nguoiNhanCap3 != null)
            {
                return Ok(new ResponseModel()
                {
                    Result = false,
                    Data = null,
                    Messgae = "Không thể xóa"
                });
            }
            else
            {
                _context.NguoiNhanCaNhans.Remove(_context.NguoiNhanCaNhans.Find(id));
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = null,
                    Messgae = "Xóa thành công"
                });
            }
        }
        [HttpDelete("NguoiNhanCap3")]
        public IActionResult Delete3(int id)
        {
           
                _context.NguoiNhanCap.Remove(_context.NguoiNhanCap.Find(id));
                _context.SaveChanges();
                return Ok(new ResponseModel()
                {
                    Result = true,
                    Data = null,
                    Messgae = "Xóa thành công"
                });
            }
        }
    

}
