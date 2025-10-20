using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Blogs.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Blogs.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsByAuthorIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetAllBlogByAuthorId(request.Id);
            return value.Select(x => new GetBlogByAuthorIdQueryResult
            {
                BlogId = x.BlogId,
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
                
            }).ToList();
        }
    }


}
