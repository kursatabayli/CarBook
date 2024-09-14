using CarBook.Application.Features.CQRS.Commands.CarCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCarsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminCarsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Araç Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _Mediator.Send(new RemoveCarCommand(id));
            return Ok("Araç Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Araç Bilgisi Güncellendi");
        }

    }
}
