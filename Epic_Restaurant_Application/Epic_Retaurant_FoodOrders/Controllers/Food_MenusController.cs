
using System.Collections.Generic;
using Epic_Retaurant_Food_Menus.Data;
using Epic_Retaurant_Food_Menus.HiddenModels;
using Microsoft.AspNetCore.Mvc;

namespace Epic_Retaurant_Food_Menus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Food_MenusController : ControllerBase
    {

        private readonly IRepository<FoodMenu> repository;
        public Food_MenusController(IRepository<FoodMenu> repos)
        {
            repository = repos;
        }

        // GET: api/Food_Menus
        [HttpGet]
        public IEnumerable<FoodMenu> Get()
        {
            return repository.GetAll();
        }

        // GET: api/Food_Menus/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Food_Menus
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Food_Menus/5
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
