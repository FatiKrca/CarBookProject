using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.TagClouds.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand : IRequest
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
    }
}
