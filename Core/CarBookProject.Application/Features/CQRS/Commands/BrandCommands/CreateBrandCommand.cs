using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string Name { get; set; }
    }
}
