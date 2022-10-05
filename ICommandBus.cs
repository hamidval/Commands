using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
   public class CommandBus : ICommandBus
    {
        public Task SendAsync<TCommand>(TCommand command) where TCommand : class 
        {
            var commandHandler = ServiceLocator.Current.GetInstance<ICommandHandler<TCommand>>();

            return commandHandler.HandleAsync(command);
        }
    }
}
