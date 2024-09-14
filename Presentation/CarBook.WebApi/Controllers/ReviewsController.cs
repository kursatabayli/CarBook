using CarBook.Application.Features.CQRS.Commands.ReviewCommands;
using CarBook.Application.Features.CQRS.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _Mediator;

		public ReviewsController(IMediator Mediator)
		{
			_Mediator = Mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ReviewList()
		{
			var values = await _Mediator.Send(new GetReviewQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetReview(int id)
		{
			var values = await _Mediator.Send(new GetReviewByIdQuery(id));
			return Ok(values);
		}		

		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			await _Mediator.Send(command);
			return Ok("Yorum Bilgisi Eklendi");
		}

		[HttpGet("GetReviewsByCarIdQuery/{id}")]
		public async Task<IActionResult> ReviewListByCarID(int id)
		{
			var values = await _Mediator.Send(new GetReviewsByCarIdQuery(id));
			return Ok(values);
		}
	}
}
