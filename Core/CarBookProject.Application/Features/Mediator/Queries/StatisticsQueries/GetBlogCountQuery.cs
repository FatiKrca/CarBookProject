using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace BlogBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetBlogCountQuery:IRequest<GetBlogCountQueryResult>
    {
    }
}
