using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Authors.Mediator.Queries.AuthorQueries;
using CarBookProject.Application.Features.Mediator.Results.AuthorResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Authors.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResults>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResults>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetAuthorQueryResults
            {
                AuthorId = x.AuthorId,
                Name = x.Name,
                Description=x.Description,
                ImageUrl=x.ImageUrl
            }).ToList();
        }
    }
}
