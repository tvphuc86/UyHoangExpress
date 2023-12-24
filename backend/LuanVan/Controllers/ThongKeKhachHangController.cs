using LuanVan.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeKhachHangController : ControllerBase

    {
        private readonly MyDbContext _context;

        public ThongKeKhachHangController(MyDbContext context)
        {
            _context = context;
        }
        // GET: api/<ThongKeKhachHangController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        // GET api/<ThongKeKhachHangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThongKeKhachHangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThongKeKhachHangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThongKeKhachHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
