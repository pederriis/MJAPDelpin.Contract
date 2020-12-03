using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MJAPDelpin.Contract.Application.Requests.Command;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MJAPDelpin.Contract.Edge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCommandController : ControllerBase
    {
        private readonly IMediator _mediator;

       public OrderCommandController(IMediator mediator)
       {
           _mediator = mediator;
       }
           // POST api/<OrderCommandController>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            //lav en post i stedet for en send, hvor mediatr sender til 2 request handlers nemlig en til at indsætte i ordre og en til ressourceorders.
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<OrderCommandController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            //det samme her med postmetode bare for update i stedet for. 
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<OrderCommandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
