using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.DTO
{
    public class DTORessource
    {
       public int RessourceId { get; set; }
        public string RessourceModelString { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }


       public DTORessource(int ressourceid, string ressourceModelString, bool isAvailable, int price)
        {
            RessourceId = ressourceid;
            RessourceModelString = ressourceModelString;
            Price = price;
            IsAvailable = isAvailable;

        }
    }
}
