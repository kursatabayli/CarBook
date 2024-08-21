using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("rentacarbylocation")]
        public async Task<IActionResult> GetAllRentACarListByLocation()
        {

            var values = await _mediator.Send(new GetAllRentACarQuery());

            return Ok(values);

        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation([FromQuery] GetRentACarQuery request)
        {

            var values = await _mediator.Send(request);

            return Ok(values);

        }
    }
}
