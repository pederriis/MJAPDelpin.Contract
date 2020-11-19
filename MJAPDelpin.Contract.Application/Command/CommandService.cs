using MJAPDelpin.Contract.Application.Interface;
using MJAPDelpin.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace MJAPDelpin.Contract.Application.Command
{
    public class CommandService :IStorageCommand
    {
        IStorageCommand _IstorageCommand;
        public CommandService(IStorageCommand IstorageCommand)
        {
            _IstorageCommand = IstorageCommand;
        }

        public void DeleteOrder(Order order)
        {
            _IstorageCommand.DeleteOrder(order);
        }

        public void InsertOrder(Order order)
        {
            _IstorageCommand.InsertOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            _IstorageCommand.UpdateOrder(order);
        }
    }
}
