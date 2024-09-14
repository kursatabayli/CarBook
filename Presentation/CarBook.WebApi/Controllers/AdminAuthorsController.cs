using CarBook.Application.Features.CQRS.Commands.AuthorCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthorsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminAuthorsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Yazar Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _Mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Yazar Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Yazar Başarıyla Güncellendi");
        }
    }
}
