using System.Collections.Generic;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {

        private IBicycleCrud _dbCrud = new EFCrud();

        // GET: api/<BicycleController>
        [HttpGet]
        public List<Bicycle> GetAllBicycles()
        {

            return _dbCrud.GetAllBicycles();

        }

        // GET api/<BicycleController>/5
        [HttpGet("{id}")]
        public Bicycle GetBycicleById(int id)
        {
            return _dbCrud.GetBicycle(id);
        }

        // POST api/<BicycleController>
        [HttpPost]
        public void AddBicycle([FromBody] Bicycle bicycle)
        {
            _dbCrud.AddBicycle(bicycle);
        }


        // PUT api/<BicycleController>/5
        [HttpPut("{id}")]
        public void RentBicycle(int id, [FromBody] int rentAction)
        {
            switch (rentAction)
            {
                case 0:
                    _dbCrud.Rent(id);
                    break;
                case 1:
                    _dbCrud.CancelRent(id);
                    break;
                default:
                    break;
            }

        }
        [HttpGet]
        [Route("types")]
        public List<BicycleType> GetAllBicycleTypes()
        {
            return _dbCrud.GetAllBicycleTypes();
        }


        // DELETE api/<BicycleController>/5
        [HttpDelete("{id}")]
        public void DeleteBicycle(int id)
        {
            _dbCrud.RemoveBicycle(id);
        }


    }
}
