using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Blogs.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetByIdAsync(request.BlogId);
            values.AuthorId = request.AuthorId;
            values.CategoryId = request.CategoryId;
            values.CreatedDate = request.CreatedDate;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Title = request.Title;
            values.Description = request.Description;

            await _repository.UpdateAsync(values);
        }
    }

}
