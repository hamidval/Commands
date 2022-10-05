using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands.ResourceCommands
{
    public class UploadResourceCommand
    {
        public ResourceDto Resource {get; set;}
        public List<ResourceFileDto> ResourceFiles { get; set; } 
        
        
    }
}
