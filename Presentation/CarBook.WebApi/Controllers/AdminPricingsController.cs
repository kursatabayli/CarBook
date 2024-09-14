using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPricingsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminPricingsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Fiyat Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _Mediator.Send(new RemovePricingCommand(id));
            return Ok("Fiyat Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Fiyat Bilgisi Güncellendi");
        }
    }
}
