using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MJAPDelpin.Contract.Edge.InfrastructureInterfaces;
using MJAPDelpin.Contract.Edge.Mapping;
using MJAPDelpin.Contract.Edge.Qurries;
using MJAPDelpin.Contract.Edge.Responses;

namespace MJAPDelpin.Contract.Edge.Handlers
{
    public class GetAllOrdersHandler:IRequestHandler<GetAllOrdersQuery,List<OrderResponse>>
    {
        private readonly IOrderQueryRepository _orderQueryRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(IOrderQueryRepository ordersQueryRepository, IMapper mapper)
        {
            _orderQueryRepository = ordersQueryRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderQueryRepository.GetOrdersAsync();
            return _mapper.MapOrdersDtoToOrderResponse(orders);
        }
    }
}
