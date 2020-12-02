using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Application.Requests.Command;

namespace MJAPDelpin.Contract.Application.Interface
{
    public interface IStorageCommand
    {
         Task<String> InsertOrder(CreateOrderCommand cmd);
         Task<Order> UpdateOrder();
         
    }
}
