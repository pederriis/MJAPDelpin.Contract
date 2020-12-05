using MediatR;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Query;
using MJAPDelpin.Contract.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Application.Handlers.Query
{
    public class GetAvailableRessourcesHandler : IRequestHandler<QueryAvailableRessources, List<DTORessource>>
    {
        private IStorageQuery storeQuery;
        public GetAvailableRessourcesHandler(IStorageQuery storeQuery)
        {
            this.storeQuery = storeQuery;
        }
        public async Task<List<DTORessource>> Handle(QueryAvailableRessources request, CancellationToken cancellationToken)
        {
            return await storeQuery.GetAvailableRessources();
        }
    }
}
