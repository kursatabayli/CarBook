using CarBook.Application.Features.CQRS.Commands.CommentCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCommentsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminCommentsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _Mediator.Send(new RemoveCommentCommand(id));
            return Ok("Yorum Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Yorum Başarıyla Güncellendi");
        }

    }
}
