using MJAPDelpin.Contract.Application.Infrastructure;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MJAPDelpin.Contract.Application.Query
{
    public class QueryService: IQueryService
    {
        IStorageQuery StorageQuery;

       public QueryService(IStorageQuery query)
        {
            StorageQuery = query;
        }

        public List<Order> GetAllOrders()
        {
            return StorageQuery.GetAllOrders();
        }

        public Order GetOrder(int id)
        {
            return StorageQuery.GetOrder(id);
        }

       
    }
}
