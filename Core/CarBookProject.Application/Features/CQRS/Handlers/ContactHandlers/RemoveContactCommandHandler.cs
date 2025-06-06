﻿ 
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using ContactBookProject.Application.Features.CQRS.Commands.ContactCommands;

namespace ContactBookProject.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            await _repository.RemoveAsync(value);

        }
    }
}
