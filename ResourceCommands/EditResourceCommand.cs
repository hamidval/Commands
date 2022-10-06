using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands.ResourceCommands
{
    public class EditResourceCommand : DeleteResourceCommand
    {
        public ResourceDto Resource { get; set; }
    }
}
