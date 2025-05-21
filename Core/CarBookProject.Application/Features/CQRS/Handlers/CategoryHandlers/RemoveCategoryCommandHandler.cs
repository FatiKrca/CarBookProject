 
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using CategoryBookProject.Application.Features.CQRS.Commands.CategoryCommands;

namespace CategoryBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);

        }
    }
}
