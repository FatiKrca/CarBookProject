using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            return new GetCarByIdQueryResult
            {

                BrandId = values.BrandId,
                Model = values.Model,
                CoverImgUrl = values.CoverImgUrl,
                Km = values.Km,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Lugage = values.Lugage,
                Fuel = values.Fuel,
                BigImageUrl = values.BigImageUrl,
                CarId = values.CarId,
                
            };

        }
    }
}
