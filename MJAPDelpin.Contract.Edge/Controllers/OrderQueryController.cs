using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MJAPDelpin.Contract.Application.Requests.Query;

namespace MJAPDelpin.Contract.Edge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query= new QueryGetAllOrders();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //// GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new QueryGetSingleOrder(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //IQueryService QueryService;

        //public OrderQueryController(IQueryService queryService)
        //{
        //    QueryService = queryService;
        //}


        //// GET: api/Order
        //[HttpGet]
        //public List<Order> Get()
        //{
        //    return QueryService.GetAllOrders();
        //}




    }
}
