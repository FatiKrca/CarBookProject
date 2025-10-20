using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.Mediator.Results.StatisticsResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentpriceForWeeklyQueryHandler : IRequestHandler<GetAvgRentpriceForWeeklyQuery, GetAvgRentpriceForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAvgRentpriceForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentpriceForWeeklyQueryResult> Handle(GetAvgRentpriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAvgRentpriceForWeekly();
            return new GetAvgRentpriceForWeeklyQueryResult
            {
                AvgRentpriceForWeekly = values
            };
        }
    }

}
