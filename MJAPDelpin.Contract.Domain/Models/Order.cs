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
        public List<DTORessource> Ressource {get; private set; }
        public DateTime CreationDate {get; private set; }

        public Order(int _id,DTOCustomer DTOcustomer,List<DTORessource> DTORessource,DateTime _creationdate)
        {
            ID = _id;
            Customer = DTOcustomer;
            Ressource = DTORessource;
            CreationDate = _creationdate;
        }
    }
}
