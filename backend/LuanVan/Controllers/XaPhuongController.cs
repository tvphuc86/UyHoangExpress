using LuanVan.Data;
using LuanVan.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LuanVan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XaPhuongController : ControllerBase
    {

        private readonly MyDbContext _context;

        public XaPhuongController(MyDbContext context)
        {   
            _context = context;
        }
        // GET: api/<XaPhuongController>
        [HttpGet]
        public IEnumerable<XaPhuong> Get(long id)
        {
            return _context.XaPhuongs.Where(m=>m.MaQuanHuyen==id).ToList();
        }

        // GET api/<XaPhuongController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<XaPhuongController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<XaPhuongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<XaPhuongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
