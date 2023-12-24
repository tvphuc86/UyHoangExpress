using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhThanhPhoController : ControllerBase

    {
        private readonly MyDbContext _context;

        public TinhThanhPhoController(MyDbContext context) {
            _context = context;
        }
        // GET: api/<TinhThanhPhoController>
        [HttpGet]
        public IEnumerable<TinhThanhPho> Get()
        {
            return _context.TinhThanhPhos.Include(m=>m.QuanHuyens).ToList();

        }
       
        // GET api/<TinhThanhPhoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.TinhThanhPhos.SingleOrDefault(m=>m.MaTinhThanhPho==id));
        }

        // POST api/<TinhThanhPhoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TinhThanhPhoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TinhThanhPhoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
