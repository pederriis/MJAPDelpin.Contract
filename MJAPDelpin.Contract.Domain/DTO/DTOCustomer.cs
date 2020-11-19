using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.Models
{
    public class DTOCustomer
    {
        int CustomerId;

       public DTOCustomer(int customerid)
        {
            CustomerId = customerid;
        }
    }
}
