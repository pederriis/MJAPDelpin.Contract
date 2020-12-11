using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MJAPDelpin.Contract.Application.Requests.Query;

namespace MJAPDelpin.Contract.Edge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/CustomerQuery/5
        [HttpGet("{id}", Name = "GetCustomerFromOderID")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new QueryGetSingleCustomerFromOrderID(id);

            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
