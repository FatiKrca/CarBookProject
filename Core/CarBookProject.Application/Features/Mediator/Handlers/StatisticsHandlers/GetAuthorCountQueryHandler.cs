using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using AuthorBookProject.Application.Features.Mediator.Results.StatisticsResults;

using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace AuthorBookProject.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAuthorCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAuthorCount();
            return new GetAuthorCountQueryResult
            {
                AuthorCount = values
            };
        }
    }

}
