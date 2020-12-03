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
    public class GetAllOrdersHandler : IRequestHandler<QueryGetAllOrders, List<Order>>
    {
        private IStorageQuery storeQuery;
        public GetAllOrdersHandler(IStorageQuery storeQuery) 
        {
            this.storeQuery = storeQuery;
        }
        public async Task<List<Order>> Handle(QueryGetAllOrders request, CancellationToken cancellationToken)
        {
            List<Order> result =  await storeQuery.GetAllOrders();
            return result.Select( order => order).ToList();
        }
    }
}
