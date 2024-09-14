using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFeaturesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminFeaturesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Özellik Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _Mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Özellik Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Özellik Başarıyla Güncellendi");
        }
    }
}
