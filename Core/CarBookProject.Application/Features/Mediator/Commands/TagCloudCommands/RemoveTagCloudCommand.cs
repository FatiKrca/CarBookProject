using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarBookProject.Application.TagClouds.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudCommand(int id)
        {
            Id = id;
        }

    }
    
}
