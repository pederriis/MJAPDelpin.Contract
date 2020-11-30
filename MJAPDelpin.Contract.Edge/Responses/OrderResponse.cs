using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Edge.Responses
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RessourceId { get; set; }
        public DateTime CreataionDate { get; set; }

    }
}
