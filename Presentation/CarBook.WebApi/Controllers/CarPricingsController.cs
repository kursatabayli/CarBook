using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public CarPricingsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

		[HttpGet("list")]
		public async Task<IActionResult> CarPricingList()
		{
			var values = await _Mediator.Send(new GetCarPricingQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCarPricing(int id)
		{
			var values = await _Mediator.Send(new GetCarPricingByIdQuery(id));
			return Ok(values);
		}

		[HttpGet("GetCarPricingWithDetails")]
		public async Task<IActionResult> GetCarPricingWithCarsList()
		{
			var values = await _Mediator.Send(new GetCarPricingWithCarsQuery());
			return Ok(values);
		}

		[HttpGet("GetCarPricingsByCarId/{id}")]
		public async Task<IActionResult> GetCarPricingsByCarId(int id)
		{
			var values = await _Mediator.Send(new GetCarPricingsByCarIdQuery(id));
			return Ok(values);
		}

	}
}
