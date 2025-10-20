using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocationBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace LocationBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetLocationCountQuery:IRequest<GetLocationCountQueryResult>
    {
    }
}
