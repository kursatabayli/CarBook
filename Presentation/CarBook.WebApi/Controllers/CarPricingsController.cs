using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarPricingList()
        {
            var values = await _mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPricing(int id)
        {
            var values = await _mediator.Send(new GetCarPricingByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat Bilgisi Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCarPricing(int id)
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
        [HttpGet("GetCarPricingWithCarsList")]
        public async Task<IActionResult> GetCarPricingWithCarsList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
            return Ok(values);
        }
    }
}
