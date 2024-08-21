using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminCarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCarPricing([FromQuery] int id)
        {
            await _mediator.Send(new RemoveCarPricingCommand(id));
            return Ok("Fiyat Bilgisi Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat Bilgisi Başarıyla Güncellendi");
        }
    }
}
