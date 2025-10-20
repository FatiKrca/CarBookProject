using AuthorBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using BlogBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using BrandBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookProject.Application.Features.CQRS.Queries.CarQueries;
using CarBookProject.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using CarCountByFuelElectricBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using LocationBookProject.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var value = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var value = await _mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(value);
        }
        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var value = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentpriceForMonthly")]
        public async Task<IActionResult> GetAvgRentpriceForMonthly()
        {
            var value = await _mediator.Send(new GetAvgRentpriceForMonthlyQuery());
            return Ok(value);
        }
        [HttpGet("GetAvgRentpriceForWeekly")]
        public async Task<IActionResult> GetAvgRentpriceForWeekly()
        {
            var value = await _mediator.Send(new GetAvgRentpriceForWeeklyQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentpriceForDaily")]
        public async Task<IActionResult> GetAvgRentpriceForDaily()
        {
            var value = await _mediator.Send(new GetAvgRentpriceForDailyQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceMaxQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var value = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var value = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(value);
        }
        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(value);
        }
    }
}
