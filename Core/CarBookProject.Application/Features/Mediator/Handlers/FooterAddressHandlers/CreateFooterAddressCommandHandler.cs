﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Adress = request.Adress,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone


            });
        }
    }
}
