using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.Models;

namespace MJAPDelpin.Contract.Edge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderQueryController : ControllerBase
    {

        IQueryService QueryService;

        public OrderQueryController(IQueryService queryService)
        {
            QueryService = queryService;
        }
        

        // GET: api/Order
        [HttpGet]
        public List<Order>Get()
        {
            return QueryService.GetAllOrders();
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

      
    }
}
