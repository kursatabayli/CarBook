using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class LocationsController : ControllerBase
	{
		private readonly IMediator _Mediator;

		public LocationsController(IMediator Mediator)
		{
			_Mediator = Mediator;
		}

		[HttpGet]
		public async Task<IActionResult> LocationList()
		{
			var values = await _Mediator.Send(new GetLocationQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetLocation(int id)
		{
			var values = await _Mediator.Send(new GetLocationByIdQuery(id));
			return Ok(values);
		}
	}
}
