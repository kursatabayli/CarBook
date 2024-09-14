using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminServicesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminServicesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Servis Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _Mediator.Send(new RemoveServiceCommand(id));
            return Ok("Servis Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Servis Bilgisi Güncellendi");
        }
    }
}
