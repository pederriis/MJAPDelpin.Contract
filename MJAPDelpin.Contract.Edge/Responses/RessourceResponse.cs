using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Edge.Responses
{
    public class RessourceResponse
    {
        public int RessourceId { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }

    }
}
