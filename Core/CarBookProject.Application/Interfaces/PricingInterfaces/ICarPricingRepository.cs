using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.PricingInterfaces
{
    public interface ICarPricingRepository
    {


        List<CarPricing> GetCarPricingWithCars();
    }
}
