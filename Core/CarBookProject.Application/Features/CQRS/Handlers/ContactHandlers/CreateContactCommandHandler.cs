 
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using ContactBookProject.Application.Features.CQRS.Commands.ContactCommands;


namespace ContactBookProject.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact
            {

                Name = command.Name,
                Email = command.Email,
                Subject = command.Subject,
                Message = command.Message,
                SendDate = command.SendDate
                



            });
        }
    }
}
