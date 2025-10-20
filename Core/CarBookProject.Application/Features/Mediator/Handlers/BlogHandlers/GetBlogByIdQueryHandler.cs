using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Blogs.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Blogs.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                AuthorId = value.AuthorId,
                CategoryId = value.CategoryId,
                CreatedDate = value.CreatedDate,
                CoverImageUrl = value.CoverImageUrl,
                Title = value.Title,
                Description = value.Description

            };
        }
    }


}
