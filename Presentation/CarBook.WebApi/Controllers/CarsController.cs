using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Queries.FuelQueries;
using CarBook.Application.Features.Mediator.Queries.LuggageQueries;
using CarBook.Application.Features.Mediator.Queries.TransmissionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var values = await _mediator.Send(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var values = await _mediator.Send(new GetLast5CarsWithBrandQuery());
            return Ok(values);
        }

        [HttpGet("CarsListWithBrandAndOtherFeatures")]
        public async Task<IActionResult> CarsListWithBrandAndOtherFeatures()
        {
            var values = await _mediator.Send(new GetCarsListWithBrandAndOtherFeaturesQuery());
            return Ok(values);
        }

        [HttpGet("GetCarDetailsById/{id}")]
        public async Task<IActionResult> GetCarDetailsById(int id)
        {
            var values = await _mediator.Send(new GetCarDetailsByIdQuery(id));
            return Ok(values);
        }


        [HttpGet("FeulTypes")]
        public async Task<IActionResult> FeulTypes()
        {
            var values = await _mediator.Send(new GetFuelQuery());
            return Ok(values);
        }

        [HttpGet("LuggageTypes")]
        public async Task<IActionResult> LuggageTypes()
        {
            var values = await _mediator.Send(new GetLuggageQuery());
            return Ok(values);
        }

        [HttpGet("TransmissionTypes")]
        public async Task<IActionResult> TransmissionTypes()
        {
            var values = await _mediator.Send(new GetTransmissionQuery());
            return Ok(values);
        }
    }
}