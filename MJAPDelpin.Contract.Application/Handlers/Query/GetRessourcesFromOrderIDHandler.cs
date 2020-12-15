using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MJAPDelpin.Contract.Application.Requests.Query;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.DTO;
using System.Threading;

namespace MJAPDelpin.Contract.Application.Handlers.Query
{
   public class GetRessourcesFromOrderIDHandler : IRequestHandler<QueryRessourcesFromOrderID, List<DTORessource>>
    {
        private IStorageQuery storeQuery;
        public GetRessourcesFromOrderIDHandler(IStorageQuery storeQuery)
        {
            this.storeQuery = storeQuery;
        }
        public async Task<List<DTORessource>> Handle(QueryRessourcesFromOrderID request, CancellationToken cancellationToken)
        {
            return await storeQuery.GetRessourcesFromOrderID(request.Id);
        }
    }
}
