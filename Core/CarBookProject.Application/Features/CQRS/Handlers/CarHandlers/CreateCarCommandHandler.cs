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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {

                BrandId = command.BrandId,
                Model = command.Model,
                CoverImgUrl = command.CoverImgUrl,
                Km = command.Km,
                Transmission = command.Transmission,
                Seat = command.Seat,
                Lugage = command.Lugage,
                Fuel = command.Fuel,
                BigImageUrl = command.BigImageUrl,
                
            });
        }
    }
}
