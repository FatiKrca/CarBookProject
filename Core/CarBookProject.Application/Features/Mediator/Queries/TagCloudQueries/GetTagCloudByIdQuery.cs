using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBookProject.Application.TagClouds.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByIdQuery : IRequest<GetTagCloudByIdQueryResult>
    {
        public GetTagCloudByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
