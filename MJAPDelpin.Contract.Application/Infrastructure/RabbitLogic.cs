using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Domain.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class RabbitLogic
    {
        private static RabbitLogic instance;
        private ConnectionFactory factory;
        private string StringRessuceCreate { get; set; } = "ressourceCreate_queue";
        private string StringRessuceUpdate { get; set; } = "ressourceUpdate_queue";
        private string StringCustomerCreate { get; set; } = "customercreate_queue";
        private string StringCustomerUpdate { get; set; } = "customerupdate_queue";

        private RabbitLogic() 
        {
            factory = new ConnectionFactory() { HostName = "localhost" };
            ListenToQueue(StringRessuceCreate);
            ListenToQueue(StringRessuceUpdate);
            ListenToQueue(StringCustomerCreate);
            ListenToQueue(StringCustomerUpdate);
        }

        private void ListenToQueue(string queeustring)
        {
            string objMesseage = "";
            //henter kunde fra Rabbit-køen.
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
                channel.QueueDeclare(queue: queeustring,//husk at ændre strengen, hvis der skal lyttes til en anden kø. 
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 10, global: false);
                //Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, ea) =>
                {
                    
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    objMesseage = message;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Received message: {0}", message);
                    Console.ResetColor();
                    //var dto = JsonConvert.DeserializeObject<DTOCustomer>(message);

                    // Note: it is possible to access the channel via
                    //       ((EventingBasicConsumer)sender).Model here
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                };
                channel.BasicConsume(queue: queeustring,
                    autoAck: false,
                    consumer: consumer);
        }

        public static RabbitLogic GetInstance() 
        {
            if (instance == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Now");
                Console.ResetColor();
                return new RabbitLogic();
            }
            else
                return instance;
        }
    }
}
