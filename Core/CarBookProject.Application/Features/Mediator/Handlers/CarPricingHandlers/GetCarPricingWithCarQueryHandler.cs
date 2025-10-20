﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;
using CarBookProject.Application.Features.Mediator.Results.LocationResults;
using CarBookProject.Application.Interfaces.PricingInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler :IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public  async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetCarPricingWithCars();
            return value.Select(x => new GetCarPricingWithCarQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingId = x.CarPricingId,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImgUrl
                





            }).ToList();
        }
    }
}
