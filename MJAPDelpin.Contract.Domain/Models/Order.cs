using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.Models
{
   public class Order
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        List<int> RessourceID { get; set; }

        DateTime CreationDate { get; set; }

        
    }
}
