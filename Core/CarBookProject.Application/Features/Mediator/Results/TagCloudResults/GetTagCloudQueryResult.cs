using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudQueryResult
    {
        public int TagCloudId { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }

    }
}
