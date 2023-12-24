using Azure.Core;
using LuanVan.Model;
using LuanVan.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhThucVanChuyenController : ControllerBase
    {
        private readonly IHinhThucVanChuyenRepository _repository;
        private readonly IWebHostEnvironment _env;

        public HinhThucVanChuyenController(IHinhThucVanChuyenRepository repository, IWebHostEnvironment env) {
            _repository = repository;
            _env = env;
        }
        // GET: api/<HinhThucVanChuyenController>
        [HttpGet]
        public async Task<IActionResult> Get(string filter="",int page=1, int limit=5)
        {
            try
            {
                var list = await _repository.GetAll(filter);
                foreach (var item in list)
                {
                    item.ImageUrl = String.Format("{0}://{1}{2}/Images/HinhThucVanChuyen/{3}", Request.Scheme, Request.Host,Request.PathBase, item.Anh);
                }
                var result = PaginatedList<HinhThucVanChuyen>.Create(list, page, limit);
                var obj = new
                {
                    result = result,
                    totalPage = result.TotalPage,
                    totalRecord = list.Count

                };
                return Ok(obj);
            }catch
            {
                return BadRequest();
            }
            
        }

        // GET api/<HinhThucVanChuyenController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(await _repository.GetById(id)==null) {
                    return NotFound();
                }
                else return Ok( await _repository.GetById(id));
            }catch
            {
                return BadRequest();
            }
        }

        // POST api/<HinhThucVanChuyenController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] HinhThucVanChuyen hinhThucVanChuyen)
        {
            try
            {
                hinhThucVanChuyen.Anh = await SaveImage(hinhThucVanChuyen.ImageFile);
                return Ok(await _repository.Add(hinhThucVanChuyen));
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<HinhThucVanChuyenController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromForm] HinhThucVanChuyen hinhThucVanChuyen)
        {

            try
            {
                if (id != hinhThucVanChuyen.HinhThucVanCHuyenId)
                {
                    return BadRequest();
                }
                else{
                    if (hinhThucVanChuyen.ImageFile != null)
                    {
                        DeleteImage(hinhThucVanChuyen.Anh);
                        hinhThucVanChuyen.Anh = await SaveImage(hinhThucVanChuyen.ImageFile);
                    }

                    return Ok(await _repository.UpDate(hinhThucVanChuyen)); 
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<HinhThucVanChuyenController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                    var obj = await _repository.GetById(id);
                if (await _repository.Delete(id)) {
                    DeleteImage(obj.Anh);
                }

                    return Ok(await _repository.Delete(id));
                
            }
            catch { 
                return BadRequest();
            }
        }
        [NonAction]
        private async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ','-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_env.ContentRootPath, "Images/HinhThucVanChuyen", imageName);
            using(var fileStream = new FileStream(imagePath, FileMode.Create))
            {
               await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        [NonAction]
        private void DeleteImage(string  imageName)
        {
            var imagePath = Path.Combine(_env.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
