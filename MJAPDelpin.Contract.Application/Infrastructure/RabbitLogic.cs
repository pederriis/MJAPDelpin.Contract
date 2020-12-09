using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class RabbitLogic
    {
        private static RabbitLogic instance;
        private ConnectionFactory factory;

        private IDatabaseLogic database;
        

        private RabbitLogic() 
        {
            factory = new ConnectionFactory() { HostName = "localhost" };

            database = new SQLDatabaseLogic();

            Thread customerCreate = new Thread(SetUpQueue);
            customerCreate.Start("customercreate_queue");

            Thread customerUpdate = new Thread(SetUpQueue);
            customerUpdate.Start("customerupdate_queue");

            Thread ResourceCreate = new Thread(SetUpQueue);
            ResourceCreate.Start("ressourceCreate_queue");

            Thread ResourceUpdate = new Thread(SetUpQueue);
            ResourceUpdate.Start("ressourceUpdate_queue");



        }

        private void SetUpQueue(object queueType)
        {
            Console.WriteLine("nu startes :"+(string)queueType);
           
            string jsonstring = "";

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
                            DTOCustomer insertCustomer = Mapper.ConvertFromJsonToDTOCustomer(jsonstring);
                            database.InsertCustomerIntoDatabase(insertCustomer);
                            break;
                        case "customerupdate_queue":
                            DTOCustomer upateCustomer = Mapper.ConvertFromJsonToDTOCustomer(jsonstring);
                            database.UpdateCustomerInDatabase(upateCustomer);
                            break;
                        case "ressourceCreate_queue":
                            DTORessource createRessource = Mapper.ConvertFromJsonToDTOResource(jsonstring);
                            database.InsertRessourceInDataBase(createRessource);
                            break;
                        case "ressourceUpdate_queue":
                            DTORessource updateRessource = Mapper.ConvertFromJsonToDTOResource(jsonstring);
                            database.UpdataRessourceInDataBase(updateRessource);
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
            }
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
