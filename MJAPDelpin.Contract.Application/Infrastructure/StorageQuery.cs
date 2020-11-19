using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
    public class StorageQuery :IStorageQuery
    {
        public Order GetOrder(int id)
        {
            return null;
        }
        public List<Order> GetAllOrders()
        {
            DTOCustomer Customer = new DTOCustomer(1);
            DTORessource Ressource = new DTORessource(1);
            List<DTORessource> Ressources = new List<DTORessource>();
            Ressources.Add(Ressource);
            Order order = new Order(1, Customer, Ressources, DateTime.Now);
            List<Order> orders = new List<Order>();
            orders.Add(order);

            return orders;
        }
    }
}
