using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Interface
{
    public interface IStorageCommand
    {
        public void InsertOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(Order order);
    }
}
