using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;

namespace CarCountByFuelElectricBookProject.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByFuelElectricQuery:IRequest<GetCarCountByFuelElectricQueryResult>
    {
    }
}
