using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MJAPDelpin.Contract.Domain.Models;

namespace MJAPDelpin.Contract.Application.Requests.Command
{
   public class CreateOrderCommand:IRequest<String>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public List<int> RessourceId { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
