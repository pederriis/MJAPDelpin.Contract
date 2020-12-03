using MJAPDelpin.Contract.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MJAPDelpin.Contract.Domain.Models
{
   public class Order
    {
        public int ID { get; private set; }
        public int CustomerId { get; private set; }
        public List<int> RessourcesId {get; private set; }
        public DateTime CreationDate {get; private set; }
        public decimal TotalPrice { get; private set; }

        public Order(int _id, int _customerId, List<int> _ressourceId, DateTime _creationdate, decimal _totalPrice)
        {
            RessourcesId = _ressourceId;
            ID = _id;
            CustomerId = _customerId;
            CreationDate = _creationdate;
            TotalPrice = _totalPrice;
        }
    }
}
