using MJAPDelpin.Contract.Domain.DTO;
using MJAPDelpin.Contract.Domain.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
   public static class Mapper
    {

        public static DTOCustomer ConvertFromJsonToDTOCustomer(string jsonstring)
        {
            var jData = JObject.Parse(jsonstring);

            //bygger en kunde ud af værdierne i jsonstringen
            int customerID = (int)jData["ID"]["CustomerID"];
            string customerName = (string)jData["Name"]["CustomerName"];


            return new DTOCustomer(customerID, customerName);

        }

        public static DTORessource ConvertFromJsonToDTOResource(string jsonstring)
        {
            var jData = JObject.Parse(jsonstring);

            int ressourceID = (int)jData["RessourceID"]["Value"];
            string ressorceModelString = (string)jData["ModelString"]["Value"];
            bool isAvailable = (bool)jData["IsAvailable"]["Value"];
            int price = (int)jData["Price"]["Value"];

            return new DTORessource(ressourceID, ressorceModelString, price, isAvailable);
        }
    }
}
