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
      
        public DateTime CreationDate { get; private set; }

        public DTOOrder(int _id,int _customerId,int _ressourceId,DateTime _creationDate)
        {
            Id = _id;
            CustomerId = _customerId;
            RessourceId = _ressourceId;
            CreationDate = _creationDate;
        }

    }
}
