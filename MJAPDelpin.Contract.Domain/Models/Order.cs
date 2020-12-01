using MJAPDelpin.Contract.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.Models
{
   public class Order
    {
        public int ID { get; private set; }
        public DTOCustomer Customer { get; private set; }
        public List<DTORessource> Ressources {get; private set; }
        public DateTime CreationDate {get; private set; }

        public Order(int _id, DTOCustomer DTOcustomer, DateTime _creationdate)
        {
            Ressources = new List<DTORessource>();
            ID = _id;
            Customer = DTOcustomer;
            CreationDate = _creationdate;
        }
    }
}
