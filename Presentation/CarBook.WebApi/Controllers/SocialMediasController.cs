using CarBook.Application.Features.CQRS.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly IMediator _Mediator;

		public SocialMediasController(IMediator Mediator)
		{
			_Mediator = Mediator;
		}

		[HttpGet]
		public async Task<IActionResult> SocialMediaList()
		{
			var values = await _Mediator.Send(new GetSocialMediaQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSocialMedia(int id)
		{
			var values = await _Mediator.Send(new GetSocialMediaByIdQuery(id));
			return Ok(values);
		}
	}
}
