using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> ReviewList()
		{
			var values = await _mediator.Send(new GetReviewQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetReview(int id)
		{
			var values = await _mediator.Send(new GetReviewByIdQuery(id));
			return Ok(values);
		}		

		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			CreateReviewValidator validator = new CreateReviewValidator();
			var validationResult = validator.Validate(command);

			if(!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			await _mediator.Send(command);
			return Ok("Yorum Bilgisi Eklendi");
		}

		[HttpGet("GetReviewsByCarIdQuery/{id}")]
		public async Task<IActionResult> ReviewListByCarID(int id)
		{
			var values = await _mediator.Send(new GetReviewsByCarIdQuery(id));
			return Ok(values);
		}
	}
}
