using MediatR;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Query;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Application.Handlers.Query
{
   public class GetSingleOrderHandler : IRequestHandler<QueryGetSingleOrder, Order>
    {
        private IStorageQuery storeQuery;
        public GetSingleOrderHandler(IStorageQuery storeQuery)
        {
            this.storeQuery = storeQuery;
        }
        public async Task<Order> Handle(QueryGetSingleOrder request, CancellationToken cancellationToken)
        {
            Order result = await storeQuery.GetOrder(request.OrderID);
            return result;
        }
    }
}
