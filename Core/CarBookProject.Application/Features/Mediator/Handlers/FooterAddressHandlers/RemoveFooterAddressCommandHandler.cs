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
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;
        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var FooterAddress = await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(FooterAddress);

        }
    }

}
