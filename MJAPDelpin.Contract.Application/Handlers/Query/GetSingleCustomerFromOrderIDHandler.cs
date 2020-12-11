using MediatR;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Query;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Application.Handlers.Query
{
    public class GetSingleCustomerFromOrderIDHandler : IRequestHandler<QueryGetSingleCustomerFromOrderID, DTOCustomer>
    {
        private IStorageQuery storeQuery;
        public GetSingleCustomerFromOrderIDHandler(IStorageQuery storeQuery)
        {
            this.storeQuery = storeQuery;
        }
        public async Task<DTOCustomer> Handle(QueryGetSingleCustomerFromOrderID request, CancellationToken cancellationToken)
        {
            DTOCustomer result = await storeQuery.GetSingleCustomerFromOrderID(request.OrderID);
            return result;
        }
    }
    
}
