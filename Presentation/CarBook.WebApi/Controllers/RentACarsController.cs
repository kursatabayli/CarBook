using CarBook.Application.Features.CQRS.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public RentACarsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet("rentacarbylocation")]
        public async Task<IActionResult> GetAllRentACarListByLocation()
        {

            var values = await _Mediator.Send(new GetAllRentACarQuery());

            return Ok(values);

        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation([FromQuery] GetRentACarQuery request)
        {

            var values = await _Mediator.Send(request);

            return Ok(values);

        }
    }
}
