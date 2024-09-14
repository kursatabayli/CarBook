using CarBook.Application.Features.CQRS.Commands.TagCloudCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTagCloudsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminTagCloudsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Etiket Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _Mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Etiket Başarıyla Güncellendi");
        }

    }
}
