using MediatR;
using MJAPDelpin.Contract.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Requests.Query
{
    public class QueryAvailableRessources : IRequest<List<DTORessource>>
    {
    }
}
