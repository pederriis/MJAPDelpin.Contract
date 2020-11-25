using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class StorageQuery :IStorageQuery
    {

        private IConfiguration Config;

        private StorageQuery(IConfiguration _config)
        {
            Config = _config;
        }

        private string GetConnectionString()
        {
            return new string("Server = den1.mssql7.gear.host; Database = delpincontract; User ID = delpincontract; Password = Up4GZLm~pDo~");
        }

        


        public Order GetOrder(int id)
        {
            SqlConnection Connection = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand("Select from Order Where id='{}'");

            return null;
        }
        public List<Order> GetAllOrders()
        {
            //DTOCustomer Customer = new DTOCustomer(1);
            //DTORessource Ressource = new DTORessource(1);
            //List<DTORessource> Ressources = new List<DTORessource>();
            //Ressources.Add(Ressource);
            //Order order = new Order(1, Customer, Ressources, DateTime.Now);
            List<Order> orders = new List<Order>();
            //orders.Add(order);

            return orders;
        }
    }
}
