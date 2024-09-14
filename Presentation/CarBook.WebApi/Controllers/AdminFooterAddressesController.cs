using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFooterAddressesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminFooterAddressesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Adres Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _Mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Adres Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Adres Başarıyla Güncellendi");
        }
    }
}
