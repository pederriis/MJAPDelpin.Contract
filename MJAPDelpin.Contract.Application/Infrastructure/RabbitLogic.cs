using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

            Thread customerCreate = new Thread(SetUpQueue);
            customerCreate.Start("customercreate_queue");

            Thread customerUpdate = new Thread(SetUpQueue);
            customerUpdate.Start("customerupdate_queue");

        }
        private void SetUpQueue(object queueType)
        {
            Console.WriteLine("nu startes :"+(string)queueType);
            //henter kunde fra Rabbit-køen.
            string jsonstring = "";

            // var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
               
            {
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (sender, ea) =>
                {
                    
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("besked modtaget [x] Received {0}", message);
                    jsonstring = message;

                    switch (queueType)
                    {
                        case "customercreate_queue":
                            HandleCustomerCreate(jsonstring);
                            break;
                        case "customerupdate_queue":
                            HandleCustomerUpdate(jsonstring);
                            break;
                        case "ressourceCreate_queue":
                            HandleResourceCreate(jsonstring);
                            break;
                        case "ressourceUreate_queue":
                            HandleResourceUpdate(jsonstring);
                            break;
                        default:
                            // code block
                            break;
                    }
                    Console.WriteLine(" [x] Done");

                    // Note: it is possible to access the channel via
                    //       ((EventingBasicConsumer)sender).Model here
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                };
                channel.BasicConsume(queue: (string)queueType,
                                     autoAck: false,
                                     consumer: consumer);
               // Console.ReadLine();
            }
        }

        public void HandleCustomerCreate(string jsonstring)
        {
            //konverter json til customer-object
            //taler med databasen 
            Console.WriteLine( "Her behandles customercreate :"+jsonstring);
        }

        public void HandleCustomerUpdate(string jsonstring)
        {
            Console.WriteLine("Her behandles Customerupdate :" + jsonstring);
        }

        public void HandleResourceCreate(string jsonstring)
        {
            Console.WriteLine("Her behandles ResourceCreate :" + jsonstring);
        }

        public void HandleResourceUpdate(string jsonstring)
        {
            Console.WriteLine("Her behandles Resourceupdate :" + jsonstring);
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
