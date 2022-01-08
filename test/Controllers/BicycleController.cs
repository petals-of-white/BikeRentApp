using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        // GET: api/<BicycleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string [] { "value1", "value2" };
        }

        // GET api/<BicycleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BicycleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        public void Rent([FromForm] string value)
        {

        }

        // PUT api/<BicycleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BicycleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        
    }
}
