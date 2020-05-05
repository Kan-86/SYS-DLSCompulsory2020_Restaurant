using EasyNetQ;
using Epic_Restaurant_Application.HiddenModels;
using Epic_Retaurant_Food_Menus.Data;
using Microsoft.Extensions.DependencyInjection;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Epic_Retaurant_Food_Menus.Infastructure
{
    public class MessageListener
    {
        IServiceProvider provider;
        string connectionString;

        // The service provider is passed as a parameter, because the class needs
        // access to the product repository. With the service provider, we can create
        // a service scope that can provide an instance of the product repository.
        public MessageListener(IServiceProvider provider, string connectionString)
        {
            this.provider = provider;
            this.connectionString = connectionString;
        }

        public void Start()
        {
            using (var bus = RabbitHutch.CreateBus(connectionString))
            {
                // already implemented
                bus.Subscribe<FoodOrderStatusChangedMessage>("productApiCompleted",
                    HandleOrderCompleted, x => x.WithTopic("completed"));

                //// delete
                //bus.Subscribe<OrderStatusChangedMessage>("productCancelled",
                //    HandleOrderCancelled, x => x.WithTopic("cancelled"));

                //// edit
                //bus.Subscribe<OrderStatusChangedMessage>("productApiCompleted",
                //    HandleOrderCompleted, x => x.WithTopic("shipped"));

                //// create
                //bus.Subscribe<OrderStatusChangedMessage>("productApiCompleted",
                //    HandleOrderCompleted, x => x.WithTopic("paid"));

                //bus.Respond<SharedProductAvailableRequest, SharedProductAvailableResponse>(request => CheckProductAvailable(request));

                // Add code to subscribe to other OrderStatusChanged events:
                // * cancelled
                // * shipped
                // * paid
                // Implement an event handler for each of these events.
                // Be careful that each subscribe has a unique subscription id
                // (this is the first parameter to the Subscribe method). If they
                // get the same subscription id, they will listen on the same
                // queue.

                // Block the thread so that it will not exit and stop subscribing.
                lock (this)
                {
                    Monitor.Wait(this);
                }
            }
        }

        private void HandleOrderCompleted(FoodOrderStatusChangedMessage message)
        {
            // A service scope is created to get an instance of the product repository.
            // When the service scope is disposed, the product repository instance will
            // also be disposed.
            using (var scope = provider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var productRepos = services.GetService<IRepository<SharedFoodMenu>>();

                // Reserve items of ordered product (should be a single transaction).
                // Beware that this operation is not idempotent.
                foreach (var orderLine in message.OrderLines)
                {
                    var product = productRepos.Get(orderLine.FoodMenuId);
                    productRepos.Edit(product);
                }
            }
        }
    }
}
