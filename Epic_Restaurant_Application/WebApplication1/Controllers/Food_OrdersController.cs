using System;
using System.Collections.Generic;
using Epic_Restaurant_Food_Orders.Data;
using Epic_Restaurant_Food_Orders.HiddenModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epic_Restaurant_Food_Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Food_OrdersController : ControllerBase
    {
        private readonly IRepository<FoodOrder> repository;

        public Food_OrdersController(IRepository<FoodOrder> repos)
        {
            repository = repos;
        }
        // GET: api/FoodOrder
        [HttpGet]
        public IEnumerable<FoodOrder> Get()
        {
            return repository.GetAll();
        }

        // GET: api/FoodOrder/5
        [HttpGet("{id}", Name = "GetOrder")]
        public string GetOrderById(int id)
        {
            return "value";
        }

        // POST: api/FoodOrder
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FoodOrder/5
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
