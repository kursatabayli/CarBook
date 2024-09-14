using CarBook.Application.Features.CQRS.Commands.LocationCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLocationsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminLocationsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Konum Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _Mediator.Send(new RemoveLocationCommand(id));
            return Ok("Konum Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Konum Başarıyla Güncellendi");
        }
    }
}
