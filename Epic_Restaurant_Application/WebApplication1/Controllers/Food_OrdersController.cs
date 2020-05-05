using System;
using System.Collections.Generic;
using Epic_Restaurant_Application.HiddenModels;
using Epic_Restaurant_Food_Orders.Data;
using Epic_Restaurant_Food_Orders.HiddenModels;
using Epic_Restaurant_Food_Orders.Infastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epic_Restaurant_Food_Orders.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Food_OrdersController : ControllerBase
    {
        private readonly IRepository<SharedFoodOrder> repository;
        private readonly IMessagePublisher messagePublisher;
        IServiceGateway<SharedFoodMenu> productServiceGateway;
        public Food_OrdersController(IRepository<SharedFoodOrder> repos, IMessagePublisher mPubl)
        {
            repository = repos;
            messagePublisher = mPubl;
        }
        // GET: api/FoodOrder
        [HttpGet]
        public IEnumerable<SharedFoodOrder> Get()
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
        public IActionResult Post([FromBody] SharedFoodOrder foodOrder)
        {
            if (foodOrder == null || foodOrder.Id < 1)
            {
                return BadRequest();
            }
            if (ProductItemsAvailable(foodOrder))
            {
                try
                {
                    // Publish OrderStatusChangedMessage. If this operation
                    // fails, the order will not be created
                    messagePublisher.PublishOrderStatusChangedMessage(
                        foodOrder.Id, foodOrder.FoodOrderLines, "completed");

                    // Create order.
                    foodOrder.Status = SharedFoodOrder.OrderStatus.completed;
                    var newOrder = repository.Add(foodOrder);
                    return CreatedAtRoute("GetOrder", new { id = newOrder.Id }, newOrder);
                }
                catch
                {
                    return StatusCode(500, "An error happened. Try again.");
                }
            }
            else
            {
                // If there are not enough product items available.
                return StatusCode(500, "Not enough items in stock.");
            }
        }

        private bool ProductItemsAvailable(SharedFoodOrder order)
        {
            foreach (var orderLine in order.FoodOrderLines)
            {
                // Call product service to get the product ordered.
                var orderedProduct = productServiceGateway.Get(orderLine.FoodMenuId);
                if (orderLine.Quantity > orderedProduct.FoodInStock)
                {
                    return false;
                }
            }
            return true;
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
