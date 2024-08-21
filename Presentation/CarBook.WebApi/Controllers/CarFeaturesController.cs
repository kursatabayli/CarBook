using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureList()
        {
            var values = await _mediator.Send(new GetCarFeatureQuery());
            return Ok(values);
        }

        [HttpGet("GetCarFeatureDetail/{id}")]
        public async Task<IActionResult> GetCarFeatureDetail(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureDetailQuery(id));
            return Ok(values);
        }        
    }
}
