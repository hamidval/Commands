﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
   public interface ICommandBus
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : class;
    }
}
