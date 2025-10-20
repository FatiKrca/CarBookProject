using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace AuthorBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAuthorCountQuery:IRequest<GetAuthorCountQueryResult>
    {
    }
}
