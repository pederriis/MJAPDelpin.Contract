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
    public class GetAllOrdersHandler :IRequestHandler<GetAllOrderResponseQuery,List<OrderResponse>>
    {
        private readonly IOrderQueryRepository orderQueryRepository;
        private readonly IMapper mapper;

        public GetAllOrdersHandler(IOrderQueryRepository orderQueryRepository, IMapper mapper)
        {
            this.orderQueryRepository = orderQueryRepository;
            this.mapper = mapper;

        }
        public async Task<List<OrderResponse>> Handle(GetAllOrderResponseQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderQueryRepository.GetOrdersAsync();
            return mapper.MapOrdersDtoToOrderResponse(orders);
        }
    }
}
