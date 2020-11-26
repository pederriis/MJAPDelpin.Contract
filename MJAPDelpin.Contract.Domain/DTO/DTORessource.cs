using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Domain.DTO
{
    public class DTORessource
    {
       public int RessourceId { get; set; }
        public string RessourceModelString { get; set; }
        public bool RessourceState { get; set; }


       public DTORessource(int ressourceid, string ressourceModelString, bool ressourceState)
        {
            RessourceId = ressourceid;

            RessourceModelString = ressourceModelString;
            RessourceState = ressourceState;

        }
    }
}
