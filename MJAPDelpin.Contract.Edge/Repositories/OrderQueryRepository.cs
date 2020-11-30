using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Edge.DTO;
using MJAPDelpin.Contract.Edge.InfrastructureInterfaces;


namespace MJAPDelpin.Contract.Edge.Repositories
{
    public class OrderQueryRepository :IOrderQueryRepository
    {
        //fyren i video har bare indsat noget mockdata, men her er det meningen at man skal hente values fra databasen og ligge det ind i listen.

        private readonly List<DTOOrder> _orders = new List<DTOOrder>();
        
        SqlConnection conn= new SqlConnection();
        
        
        //{
        //    new DTOOrder
        //    {
        //        Id = ,
        //        DeliveryDate = DateTime.UtcNow,
        //        ProductId = Guid.Parse("9f8dd03e-1298-4070-adc0-c21bbd5e179f"),
        //        CustomerId = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"),
        //        Delivered = false
        //    }
        //};
        //hernede henter han bare data fra den samme liste så det her er okay, da den går ind i en liste a orders, som hentes fra SQL databasen.
        public Task<DTOOrder> GetOrderAsync(int orderId)
        {
            return Task.FromResult(_orders.SingleOrDefault(x => x.Id == orderId));
        }

    }
}
