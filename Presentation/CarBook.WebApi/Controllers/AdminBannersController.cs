using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBannersController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminBannersController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Banner Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _Mediator.Send(new RemoveBannerCommand(id));
            return Ok("Banner Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Banner Bilgisi Güncellendi");
        }
    }
}
