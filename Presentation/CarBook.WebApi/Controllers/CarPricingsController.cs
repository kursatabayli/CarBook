using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet("list")]
		public async Task<IActionResult> CarPricingList()
		{
			var values = await _mediator.Send(new GetCarPricingQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCarPricing(int id)
		{
			var values = await _mediator.Send(new GetCarPricingByIdQuery(id));
			return Ok(values);
		}

		[HttpGet("GetCarPricingWithDetails")]
		public async Task<IActionResult> GetCarPricingWithCarsList()
		{
			var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
			return Ok(values);
		}

		[HttpGet("GetCarPricingDayWeekMonthById/{id}")]
		public async Task<IActionResult> GetCarPricingDayWeekMonthById(int id)
		{
			var values = await _mediator.Send(new GetCarPricingDayWeekMonthByIdQuery(id));
			return Ok(values);
		}

	}
}
