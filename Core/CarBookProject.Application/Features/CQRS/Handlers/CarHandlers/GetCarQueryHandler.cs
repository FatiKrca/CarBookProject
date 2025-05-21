using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using CarBookProject.Application.Interfaces;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
           

            return values.Select(x=>new GetCarQueryResult
            {
               
                CarId = x.CarId,
                BrandId = x.BrandId,
                Model = x.Model,
                CoverImgUrl = x.CoverImgUrl,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Lugage = x.Lugage,
                Seat = x.Seat,
                Transmission = x.Transmission,
                

            }).ToList();
        }
    }
}
