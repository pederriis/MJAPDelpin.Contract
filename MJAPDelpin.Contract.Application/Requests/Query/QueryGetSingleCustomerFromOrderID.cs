using MediatR;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Requests.Query
{
   public class QueryGetSingleCustomerFromOrderID : IRequest<DTOCustomer>
    {
        public int OrderID { get; private set; }

        public QueryGetSingleCustomerFromOrderID(int orderID)
        {
            OrderID = orderID;
        }
    
    }
}
