﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using CategoryBookProject.Application.Features.CQRS.Commands.CategoryCommands;
 

namespace CategoryBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category
            {

                Name = command.Name



            });
        }
    }
}
