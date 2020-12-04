using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Command;


namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class StorageCommand : IStorageCommand
    {
        private static IDatabaseLogic _databaseLogic;
        private static readonly string Conn = Utillities.ConnectionString;

        public StorageCommand()
        {
            _databaseLogic = new SQLDatabaseLogic();
            
        }

        private static SqlConnection getConnection()
        {
            return new SqlConnection(Conn);
        }

        public Task<String> InsertOrder(CreateOrderCommand request)
        {
            if (!_databaseLogic.CheckIfCustomerExist(request.CustomerId))
            {
                return Task<string>.Factory.StartNew(() => "Hovsa, den kunde findes ikke.");
                // throw new Exception("Error occured while checking if customer exist");
            }

            string Result = addOrderToDatabase(request);
            addRessourceOrderToDatabase(request);
            return Task.FromResult(Result);


            // lav en add ressourceorder to database i denne her klasse.

        }

        public Task<String> UpdateOrder(UpdateOrderCommand request)
        {
            return Task.FromResult(updateOrderInDatabase(request));
        }


        private Func<UpdateOrderCommand, string> updateOrderInDatabase = (UpdateOrderCommand cmd) =>
        {
            string query = $"Update Orders " +
                           $"set TotalPrice = {cmd.TotalPrice} " +
                           $"where Id ={cmd.Id} ";

            SqlCommand Command = new SqlCommand(query, getConnection());
            Command.Connection.Open();
            int result = Command.ExecuteNonQuery();
            Command.Connection.Close();
            if (result < 0)
            {
                return "Error Updating data in database";
                //evt. tilføj en exception mediatr her, som kan sende en error videre til en requesthandler.
            }
            else
            {
                return "Update executed in database";
            }
        };



        /*Private methods below*/
        private Func<CreateOrderCommand, string> addOrderToDatabase = (CreateOrderCommand cmd) =>
        {
            
            string query = $"SET IDENTITY_INSERT Orders ON Insert into orders(Id,CustomerId,Date,TotalPrice)"
                           + "values"
                           + $"({cmd.Id},"
                           + $"{cmd.CustomerId},"
                           + $"{DateTime.Now.ToShortDateString()},"
                           + $"{cmd.TotalPrice})";



            SqlCommand command = new SqlCommand(query, getConnection());
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();
            // Check Error
            if (result < 0)
                return "Error inserting data into Database!";
            else 
                return "nu er der vistnok skrevet en Ordre i databasen";

        };
        private Func<CreateOrderCommand, string> addRessourceOrderToDatabase = (CreateOrderCommand cmd) =>
        {
            int result=0;
            foreach (var Ressources in cmd.RessourceId)
            {
                if (!_databaseLogic.CheckIfRessourceExist(Ressources))
                {
                    throw new Exception("ressources does not exist");
                }
            string query = $"Insert into RessourceOrders(OrderId,RessourceId)"
                           + "values"
                           + $"({cmd.Id},"
                           + $"{Ressources})";
             SqlCommand command = new SqlCommand(query, getConnection());
             command.Connection.Open();
             result = command.ExecuteNonQuery();
             command.Connection.Close();
            }
            // Check Error
            if (result < 0)
                return "Error inserting data into Database!";
            else
                return "nu er der vistnok skrevet en kunde i databasen";

        };

        //private bool checkIfCustomerExist(string query, int id)
        //{
        //    //der findes en måde at checke om en ting findes i en database, uden en select. den skal retunere en bool.
        //    if (Request.QueryString["aspxerrorpath"] != null)
        //    {
        //        //your code that depends on aspxerrorpath here
        //    }
        //}
    }
}
