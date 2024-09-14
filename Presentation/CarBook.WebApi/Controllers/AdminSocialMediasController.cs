using CarBook.Application.Features.CQRS.Commands.SocialMediaCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminSocialMediasController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminSocialMediasController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _Mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal Medya Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Güncellendi");
        }
    }
}
