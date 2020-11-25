using System;
using System.Collections.Generic;
using System.Text;
using MJAPDelpin.Contract.Domain.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class RabbitLogic
    {
        public void GetCustomerCreatedFromRabbit()
        {
            //henter kunde fra Rabbit-køen.

            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "customercreate_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Customer [x] Received {0}", message);
                    var dto = JsonConvert.DeserializeObject<DTOCustomer>(message);



                    // Note: it is possible to access the channel via
                    //       ((EventingBasicConsumer)sender).Model here
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                };
                channel.BasicConsume(queue: "customercreate_queue",
                    autoAck: false,
                    consumer: consumer);
             
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();

            }
        }




    }
}
