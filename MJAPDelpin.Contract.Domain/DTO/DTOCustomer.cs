using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.Models
{
    public class DTOCustomer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }

       public DTOCustomer(int customerid, string name)
        {
            CustomerId = customerid;
            Name = name;

        }
    }
}
