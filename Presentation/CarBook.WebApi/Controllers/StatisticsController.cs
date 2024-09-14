using CarBook.Application.Features.CQRS.Queries.StatisticQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public StatisticsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _Mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAutomaticCount")]
        public async Task<IActionResult> GetAutomaticCount()
        {
            var values = await _Mediator.Send(new GetAutomaticCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _Mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _Mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _Mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetHighestCarBrandCount")]
        public async Task<IActionResult> GetHighestCarBrandCount()
        {
            var values = await _Mediator.Send(new GetHighestCarBrandQuery());
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _Mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetDailyAverageCarRentingPrice")]
        public async Task<IActionResult> GetDailyAverageCarRentingPrice()
        {
            var values = await _Mediator.Send(new GetDailyAverageCarRentingPriceQuery());
            return Ok(values);
        }

        [HttpGet("GetWeeklyAverageCarRentingPrice")]
        public async Task<IActionResult> GetWeeklyAverageCarRentingPrice()
        {
            var values = await _Mediator.Send(new GetWeeklyAverageCarRentingPriceQuery());
            return Ok(values);
        }

        [HttpGet("GetMonthlyAverageCarRentingPrice")]
        public async Task<IActionResult> GetMonthlyAverageCarRentingPrice()
        {
            var values = await _Mediator.Send(new GetMonthlyAverageCarRentingPriceQuery());
            return Ok(values);
        }
        
        [HttpGet("GetTestimonialsCount")]
        public async Task<IActionResult> GetTestimonialsCount()
        {
            var values = await _Mediator.Send(new GetTestimonialsCountQuery());
            return Ok(values);
        }

    }
}
