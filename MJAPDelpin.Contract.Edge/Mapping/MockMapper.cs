using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Edge.DTO;
using MJAPDelpin.Contract.Edge.Responses;

namespace MJAPDelpin.Contract.Edge.Mapping
{
    public class MockMapper : IMapper
    {
        public List<OrderResponse> MapOrdersDtoToOrderResponse(List<DTOOrder> orders)
        {
            return orders.Select(order => new OrderResponse
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                RessourceId = order.RessourceId,
                CreataionDate = order.CreationDate
            }).ToList();

        }
            public OrderResponse MapOrderDtoToOrderResponse(DTOOrder order)
            {
                return new OrderResponse
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    RessourceId = order.RessourceId,
                    CreataionDate = order.CreationDate
                };
            }
        
    }
}
