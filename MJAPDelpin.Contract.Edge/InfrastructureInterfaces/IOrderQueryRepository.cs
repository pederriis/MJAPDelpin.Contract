using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Edge.DTO;

namespace MJAPDelpin.Contract.Edge.InfrastructureInterfaces
{
    public interface IOrderQueryRepository
    {
        Task<List<DTOOrder>> GetOrdersAsync();
        Task<DTOOrder> GetOrderAsync(int Id);
    }
}
