using CarBook.Application.Features.CQRS.Commands.ReviewCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminReviewsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminReviewsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReview(int id)
        {
            await _Mediator.Send(new RemoveReviewCommand(id));
            return Ok("Yorum Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Yorum Bilgisi Güncellendi");
        }
    }
}
