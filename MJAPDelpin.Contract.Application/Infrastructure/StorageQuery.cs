using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class StorageQuery : IStorageQuery
    {

        public Task<Order> GetOrder(int id)
        {
            return Task.FromResult(orderDelegateSingle($"Select from Orders Where id='{id}'"));
        }

        public Task<List<Order>> GetAllOrders()
        {
            return Task.FromResult(orderDelegateAll("Select * from Orders"));
        }


        /*----------------------------PRIVATE-METHODS-------------------------------------------*/
        private static string GetConnectionString()
        {
            return new string("Server = den1.mssql7.gear.host; Database = delpincontract; User ID = delpincontract; Password = Up4GZLm~pDo~");
        }

        private Func<string, List<Order>> orderDelegateAll = (string query) =>
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<Order> orderList = new List<Order>();
            //using (SqlDataReader reader = command.ExecuteReader())
            //    while (reader.Read())
            //        orderList.Add(new Order(
            //        Convert.ToInt32(reader["Id"].ToString()), null, Convert.ToDateTime(reader["Date"])
            //        ));
            return orderList;
        };

        private Func<string, Order> orderDelegateSingle = (string query) =>
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            Order order = new Order(0,0, null, DateTime.Now, 0);
            //using (SqlDataReader reader = command.ExecuteReader())
            //    while (reader.Read())
            //        order = new Order(
            //        Convert.ToInt32(reader["Id"].ToString()), null, Convert.ToDateTime(reader["Date"])
            //        );
            return order;
        };



        /*Possible refactor option, generic delegates
            private delegate TResult Func<in T , out TResult> (  T arg );
        */

    }
}
