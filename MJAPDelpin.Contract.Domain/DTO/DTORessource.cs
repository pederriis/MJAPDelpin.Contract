using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.DTO
{
    public class DTORessource
    {
       public int RessourceId { get; set; }
        public string ModelString { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }


       public DTORessource(int ressourceid, string modelString, int price, bool isAvailable)
        {
            RessourceId = ressourceid;
            ModelString = modelString;
            Price = price;
            IsAvailable = isAvailable;

        }
    }
}
