using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBookProject.Application.Features.RepositoryPattern;
using CarBookProject.Application.Interfaces;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Application.Interfaces.PricingInterfaces;
using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Application.Interfaces.TagCloudInterfaces;
using CarBookProject.Domain.Entities;
using CarBookProject.Persistence.Context;
using CarBookProject.Persistence.Repositories;
using CarBookProject.Persistence.Repositories.BlogRepositories;
using CarBookProject.Persistence.Repositories.CarRepositories;
using CarBookProject.Persistence.Repositories.CommentRepositories;
using CarBookProject.Persistence.Repositories.PricingRepositories;
using CarBookProject.Persistence.Repositories.StatisticsRpository;
using CarBookProject.Persistence.Repositories.TagCloudRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarBookProject.Persistence.DependencyInjection
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<CarBookContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
            services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
            services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
            services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
            services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
            services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
 
            return services;
        }
    }
}
