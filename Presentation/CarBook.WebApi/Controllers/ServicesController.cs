using CarBook.Application.Features.CQRS.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IMediator _Mediator;

		public ServicesController(IMediator Mediator)
		{
			_Mediator = Mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ServiceList()
		{
			var values = await _Mediator.Send(new GetServiceQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetService(int id)
		{
			var values = await _Mediator.Send(new GetServiceByIdQuery(id));
			return Ok(values);
		}
	}
}
