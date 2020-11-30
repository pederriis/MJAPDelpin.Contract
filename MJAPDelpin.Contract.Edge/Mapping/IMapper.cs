using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MJAPDelpin.Contract.Edge.DTO;
using MJAPDelpin.Contract.Edge.Responses;

namespace MJAPDelpin.Contract.Edge.Mapping
{
   public interface IMapper
   {
       public List<OrderResponse> MapOrdersDtoToOrderResponse(List<DTOOrder> orders);
       public OrderResponse MapOrderDtoToOrderResponse(DTOOrder order);
    }
}
