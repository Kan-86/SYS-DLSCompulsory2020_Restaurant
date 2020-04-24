using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epic_Restaurant_Application.Data;
using Epic_Restaurant_Application.HiddenModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epic_Restaurant_Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Food_OrdersController : ControllerBase
    {
        private readonly IRepository<FoodMenu> repository;

        public Food_OrdersController(IRepository<FoodMenu> repos)
        {
            repository = repos;
        }
        // GET: api/FoodMenu
        [HttpGet]
        public IEnumerable<FoodMenu> Get()
        {
            return repository.GetAll();
        }

        // GET: api/FoodMenu/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FoodMenu
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FoodMenu/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
