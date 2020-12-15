using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MJAPDelpin.Contract.Application.Requests.Query;

namespace MJAPDelpin.Contract.Edge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RessourceQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RessourceQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableRessources() 
        {
            var query = new QueryAvailableRessources();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetRessourcesFromOrderId")]
        public async Task<IActionResult> GetRessourcesFromOrderId(int id)
        {
            var query = new QueryRessourcesFromOrderID(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
