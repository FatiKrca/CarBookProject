using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarId);

            value.Fuel = command.Fuel;
            value.Km = command.Km;
            value.Lugage = command.Lugage;
            value.Seat = command.Seat;
            value.Transmission = command.Transmission;
            value.BrandId = command.BrandId;
            value.Model = command.Model;
            value.CoverImgUrl = command.CoverImgUrl;
            value.BigImageUrl = command.BigImageUrl;

            await _repository.UpdateAsync(value);

        }
    }
}
