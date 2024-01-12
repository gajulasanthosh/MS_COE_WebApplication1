using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MS_COE_WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> data = new List<string> { "Laptop", "Mobile", "Mouse", "Tablet" };
        private readonly AppDbContext _context;

        public ValuesController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return new string[] { "value1", "value2" };
            return Ok(data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if(id >= 0)
            {
                return Ok(data[id]);
            }
            return NotFound();
            //return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            data.Add(value);
            return Ok(data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if(id >= 0)
            {
                data[id] = value;
                return Ok(data);
            }
            return NotFound(id);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id >= 0)
            {
                data.RemoveAt(id);
                return Ok(data);
            }
            return NotFound(id);
            
        }
    }
}
