using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Edge.DTO
{
    public class DTOOrder
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public int RessourceId { get; private set; }
        public bool IsAvailable { get; private set; }
        public DateTime CreationDate { get; private set; }
        public decimal TotalPrice { get; private set; }

        public DTOOrder(int id,int customerId,int ressourceId, bool isAvailable, DateTime creationDate)
        {
            Id = id;
            CustomerId = customerId;
            RessourceId = ressourceId;
            IsAvailable = isAvailable;
            CreationDate = creationDate;
        }

    }
}
