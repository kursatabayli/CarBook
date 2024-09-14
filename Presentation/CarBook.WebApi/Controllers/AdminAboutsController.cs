using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAboutsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminAboutsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Hakkımda Bilgisi Eklendi");
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _Mediator.Send(new RemoveAboutCommand(id));
            return Ok("Hakkımda Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Hakkımda Bilgisi Güncellendi");
        }
    }
}
