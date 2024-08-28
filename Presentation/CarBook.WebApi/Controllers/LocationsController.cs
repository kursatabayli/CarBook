using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LocationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> LocationList()
		{
			var values = await _mediator.Send(new GetLocationQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetLocation(int id)
		{
			var values = await _mediator.Send(new GetLocationByIdQuery(id));
			return Ok(values);
		}
	}
}
