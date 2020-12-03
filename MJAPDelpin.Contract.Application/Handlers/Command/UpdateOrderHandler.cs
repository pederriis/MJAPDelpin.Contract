using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Application.Requests.Command;

namespace MJAPDelpin.Contract.Application.Handlers.Command
{
    public class UpdateOrderHandler:IRequestHandler<UpdateOrderCommand,String>
    {
        private IStorageCommand _storageCommand;

        UpdateOrderHandler(IStorageCommand storageCommand)
        {
            _storageCommand = storageCommand;
        }

        public async Task<String> Handle(UpdateOrderCommand request, CancellationToken token)
        {
            return await _storageCommand.UpdateOrder(request);
        }
    }
}
