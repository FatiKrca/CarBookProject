using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace BrandBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetBrandCountQuery:IRequest<GetBrandCountQueryResult>
    {
    }
}
