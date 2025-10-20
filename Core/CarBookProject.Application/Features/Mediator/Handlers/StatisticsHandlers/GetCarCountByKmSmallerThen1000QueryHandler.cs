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
    public class GetCarCountByKmSmallerThen1000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThen1000Query, GetCarCountByKmSmallerThen1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByKmSmallerThen1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByKmSmallerThen1000QueryResult> Handle(GetCarCountByKmSmallerThen1000Query request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByKmSmallerThen1000();
            return new GetCarCountByKmSmallerThen1000QueryResult
            {
                CarCountByKmSmallerThen1000 = values
            };
        }
    }

}
