using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MJAPDelpin.Contract.Domain.DTO;

namespace MJAPDelpin.Contract.Application.Requests.Query
{
    public class QueryRessourcesFromOrderID : IRequest<List<DTORessource>>
    {
      public  int Id { get; private set; }

        public QueryRessourcesFromOrderID(int id)
        {
            Id = id;
        }

    }
}
