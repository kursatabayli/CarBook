using CarBook.Application.Features.CQRS.Commands.CommentCommands;
using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public CommentsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _Mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var values = await _Mediator.Send(new GetCommentByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Yorum Başarıyla Eklendi");
        }

        [HttpGet("CommentByBlogId/{id}")]
        public async Task<IActionResult> CommentByBlogId(int id)
        {
            var values = await _Mediator.Send(new GetCommentByBlogIdQuery(id));
            return Ok(values);
        }
    }
}
