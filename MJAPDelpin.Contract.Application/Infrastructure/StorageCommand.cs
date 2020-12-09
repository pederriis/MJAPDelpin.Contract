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
        private static Func<string, string> messageDelegate = (string message) => { return message; };
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
            Result += addRessourceOrderToDatabase(request);
            return Task.FromResult(Result);

            // lav en add ressourceorder to database i denne her klasse.
        }

        public Task<string> UpdateOrder(UpdateOrderCommand updateRequest)
        {
            return Task.FromResult(updateOrderInDatabase(updateRequest));
        }

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
            int result = 0;
            foreach (var ressource in cmd.RessourceId)
            {
                bool notExistence = !_databaseLogic.CheckIfRessourceExist(ressource);
                bool noneAvailability = !_databaseLogic.CheckAvailability(ressource);
                if (notExistence || noneAvailability)
                    continue;

                string query = $"Insert into RessourceOrders(OrderId,RessourceId)"
                           + "values"
                           + $"({cmd.Id},"
                           + $"{ressource})";
                SqlCommand command = new SqlCommand(query, getConnection());
                command.Connection.Open();
                result = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            // Check Error
            if (result < 0)
                return " Error inserting data into Database!";
            else
                return " nu er der vistnok i databasen";
        };

        private Func<UpdateOrderCommand, string> updateOrderInDatabase = (UpdateOrderCommand cmd) =>
        {
            string query = $"Update Orders set " +
                           $"Date = @CreationDate," +
                           $"TotalPrice = @TotalPrice " +
                           $"where Id = @Id";

            using (SqlCommand command = new SqlCommand(query, getConnection()))
            {
                command.Parameters.AddWithValue("@Id", cmd.Id);
                command.Parameters.AddWithValue("@CreationDate", cmd.CreationDate);
                command.Parameters.AddWithValue("@TotalPrice", cmd.TotalPrice);

                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
                if (result < 0)
                    return messageDelegate("Error Updating data in database");
                else//evt. tilføj en exception mediatr her, som kan sende en error videre til en requesthandler.
                    return messageDelegate("Update executed in database");
            }
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
