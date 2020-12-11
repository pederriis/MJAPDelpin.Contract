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
            return Task.FromResult(orderDelegateSingle("select Orders.Id as orderid, "
                + "Orders.Date as orderdate, "
                + "Orders.TotalPrice as ordertotalprice,"
                + "customers.Id as customerid, "
                + "Customers.Name as customername "
                + " from Orders "
                + "join Customers on Orders.CustomerId = Customers.Id "
                +$"where orders.id={id}"));
        }

        public Task<List<Order>> GetAllOrders()
        {
            return Task.FromResult(orderDelegateAll("select Orders.Id as orderid, "
                +"Orders.Date as orderdate, "
                +"Orders.TotalPrice as ordertotalprice, "
                +"customers.Id as customerid, "
                +"Customers.Name as customername "
                +" from Orders "
                +"join Customers on Orders.CustomerId = Customers.Id "
               ));
        }

        public Task<List<DTORessource>> GetAvailableRessources() 
        {
            return Task.FromResult(
                RessourceDelegateGetAvailable(
                    $"select *" +
                    $"from ressources " +
                    $"where IsAvailable = 1"));
        }
        
        public Task<DTOCustomer> GetSingleCustomerFromOrderID(int id)
        {
            return Task.FromResult(
                CustomerDelegateSingle(
                    "select customers.Id as customerid, "
                    + "Customers.Name as customername "
                    + "from customers "
                    + "join orders on Customers.Id = Orders.CustomerId "
                    + $"where orders.Id = {id} "

                    ));
        }

        /*----------------------------PRIVATE-METHODS-------------------------------------------*/
        private static string GetConnectionString()
        {
            return Utillities.ConnectionString;
        }

        private Func<string, List<Order>> orderDelegateAll = (string query) =>
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<Order> orderList = new List<Order>();
            using (SqlDataReader reader = command.ExecuteReader())

                while (reader.Read())
                {
                    DTOCustomer customer = new DTOCustomer((int)reader["customerid"], (string) reader["customername"]);
                    List<DTORessource> ressourceList = GetRessourcesFromRessorceOrderID((int)reader["orderid"]);
                    List<int> ressourceIntList = new List<int>();

                    foreach (DTORessource res in ressourceList)
                    {
                        ressourceIntList.Add(res.RessourceId);
                    }

                    Order order= new Order((int)reader["orderid"], customer.CustomerId, ressourceIntList, (DateTime)reader["orderdate"],Convert.ToInt32( reader["ordertotalprice"]) );
                   
                    orderList.Add(order);
                }
    
            return orderList;
        };

        private Func<string, Order> orderDelegateSingle = (string query) =>
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            List <DTORessource> ressorces= new List<DTORessource>();
            Order order = null;
            using (SqlDataReader reader = command.ExecuteReader())

                while (reader.Read())
                {
                    DTOCustomer customer = new DTOCustomer((int)reader["customerid"], (string)reader["customername"]);
                    List<DTORessource> ressourceList = GetRessourcesFromRessorceOrderID((int)reader["orderid"]);

                    List<int> ressourceIntList = new List<int>();

                    foreach (DTORessource res in ressourceList)
                    {
                        ressourceIntList.Add(res.RessourceId);
                    }

                    Order tmporder = new Order((int)reader["orderid"], customer.CustomerId, ressourceIntList, (DateTime)reader["orderdate"], Convert.ToInt32( reader["ordertotalprice"]));

                    order = tmporder;
                }

            return order;
        };
        
        private Func<string, List<DTORessource>> RessourceDelegateGetAvailable = (string query) => 
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            using (SqlCommand command = new SqlCommand(query, connection)) 
            {
                List<DTORessource> ressourceList = new List<DTORessource>();
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                        ressourceList.Add(new
                            DTORessource(
                                (int)reader["Id"],
                                (string)reader["Modelstring"],
                                Convert.ToInt32(reader["Price"]),
                                (bool)reader["IsAvailable"]));

                return ressourceList;
            }
        };

        private static Func<int, List<DTORessource>> GetRessourcesFromRessorceOrderID = (int ressourceOrderID) =>
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            string query = $"select Ressources.Id as ressourceid, " +
                $"Ressources.Modelstring as ressourcemodelstring ," +
                $" Ressources.Price as ressourceprice ," +
                $" Ressources.IsAvailable as IsAvailable " +
                $"from RessourceOrders " +
                $"join Ressources on RessourceOrders.RessourceId = Ressources.Id where orderid = {ressourceOrderID}";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            List<DTORessource> ressorceList = new List<DTORessource>();
            using (SqlDataReader reader = command.ExecuteReader())

                while (reader.Read())
                {
                    DTORessource ressource = new DTORessource((int)reader["ressourceid"],
                                                               (string)reader["ressourcemodelstring"],
                                                                Convert.ToInt32(reader["ressourceprice"]),
                                                               (bool)reader["IsAvailable"]);
                    ressorceList.Add(ressource);
                }

            return ressorceList;
        };


        private Func<string, DTOCustomer> CustomerDelegateSingle = (string query) =>
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
           
            DTOCustomer customer = null;
            using (SqlDataReader reader = command.ExecuteReader())

                while (reader.Read())
                {
                     customer = new DTOCustomer((int)reader["customerid"], (string)reader["customername"]);
                   
                }

            return customer;
        };

        /*Possible refactor option, generic delegates
            private delegate TResult Func<in T, out TResult>(T arg);
        */
    }
}
