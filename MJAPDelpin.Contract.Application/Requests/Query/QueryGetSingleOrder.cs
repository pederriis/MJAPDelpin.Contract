using MediatR;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Requests.Query
{
    public class QueryGetSingleOrder : IRequest<Order>
    {
        public int OrderID { get; private set; }

        public QueryGetSingleOrder(int orderID)
        {
            OrderID = orderID;
        }
    }
}
