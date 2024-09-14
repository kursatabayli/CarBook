using CarBook.Application.Features.CQRS.Commands.BlogCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBlogsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminBlogsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _Mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog Başarıyla Silindi");
        }
    }
}
