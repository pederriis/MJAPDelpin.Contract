﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MJAPDelpin.Contract.Edge.Responses;

namespace MJAPDelpin.Contract.Edge.Commands
{
    public class CreateOrderCommand:IRequest<OrderResponse>
    {
    }
}
