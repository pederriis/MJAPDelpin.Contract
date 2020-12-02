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
        private static readonly string Conn = Utillities.ConnectionString;

        private static SqlConnection getConnection()
        {
            return new SqlConnection(Conn);
        }
        public Task<String> InsertOrder(CreateOrderCommand request)
        {
            return Task.FromResult(addOrderToDatabase(request));

            

            // Hvad mangler?
            //1. lav query streng 2. lav en add ressourceorder to database i denne her klasse.

            //insert order i databasen.
        }


        public Task<Order> UpdateOrder()
        {
            throw new NotImplementedException();
        }



        /*Private methods below*/
        private Func<CreateOrderCommand, string> addOrderToDatabase = (CreateOrderCommand cmd) =>
        {
            string query = $"Insert into orders(CustomerId,Date,TotalPrice)"
                           + "values"
                           + $"({cmd.CustomerId},"
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
