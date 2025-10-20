using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByKmSmallerThen1000Query:IRequest<GetCarCountByKmSmallerThen1000QueryResult>
    {
    }
}
