using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Command;
using MJAPDelpin.Contract.Domain.Models;

namespace MJAPDelpin.Contract.Application.Handlers.Command
{
    public class CreateOrderHandler:IRequestHandler<CreateOrderCommand,String>
    {
        private IStorageCommand _storageCommand;

        public CreateOrderHandler(IStorageCommand storageCommand)
        {
            _storageCommand = storageCommand;
        }
        public async Task<String> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _storageCommand.InsertOrder(request);
        }
    }
}
