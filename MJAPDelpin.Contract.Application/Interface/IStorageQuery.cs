using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJAPDelpin.Contract.Application.Interface
{
    public interface IStorageQuery
    {
        Task<Order> GetOrder(int id);
        Task<List<Order>> GetAllOrders();
    }
}
