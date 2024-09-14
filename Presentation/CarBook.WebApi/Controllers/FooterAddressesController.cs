using CarBook.Application.Features.CQRS.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FooterAddressesController : ControllerBase
	{
		private readonly IMediator _Mediator;

		public FooterAddressesController(IMediator Mediator)
		{
			_Mediator = Mediator;
		}

		[HttpGet]
		public async Task<IActionResult> FooterAddressList()
		{
			var values = await _Mediator.Send(new GetFooterAddressQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFooterAddress(int id)
		{
			var values = await _Mediator.Send(new GetFooterAddressByIdQuery(id));
			return Ok(values);
		}
	}
}
