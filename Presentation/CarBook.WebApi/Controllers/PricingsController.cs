using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PricingsController : ControllerBase
	{
		private readonly IMediator _Mediator;

		public PricingsController(IMediator Mediator)
		{
			_Mediator = Mediator;
		}

		[HttpGet]
		public async Task<IActionResult> PricingList()
		{
			var values = await _Mediator.Send(new GetPricingQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPricing(int id)
		{
			var values = await _Mediator.Send(new GetPricingByIdQuery(id));
			return Ok(values);
		}
	}
}
