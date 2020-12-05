using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Interface
{
   public interface IDatabaseLogic
    {

        public void InsertCustomerIntoDatabase(DTOCustomer customer);

        public void UpdateCustomerInDatabase(DTOCustomer customer);

        public void InsertRessourceInDataBase(DTORessource ressource);

        public void UpdataRessourceInDataBase(DTORessource resource);

        public bool CheckIfCustomerExist(int orderID);

        public bool CheckIfRessourceExist(int ressourceID);

    }
}
