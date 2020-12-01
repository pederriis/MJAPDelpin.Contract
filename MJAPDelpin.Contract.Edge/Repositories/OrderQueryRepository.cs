using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Threading.Tasks;
using MJAPDelpin.Contract.Edge.DTO;
using MJAPDelpin.Contract.Edge.InfrastructureInterfaces;


namespace MJAPDelpin.Contract.Edge.Repositories
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly List<DTOOrder> _orders = new List<DTOOrder>();
        
        public Task<DTOOrder> GetOrderAsync(int orderId)
        {
            return Task.FromResult( _orders.SingleOrDefault(x => x.Id == orderId) );
        }

        public Task<List<DTOOrder>> GetOrdersAsync()
        {
            return Task.FromResult( _orders.Select(o => o).ToList() );
        }
    }
}
