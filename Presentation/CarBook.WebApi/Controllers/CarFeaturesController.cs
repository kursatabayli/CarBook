using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public CarFeaturesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureList()
        {
            var values = await _Mediator.Send(new GetCarFeatureQuery());
            return Ok(values);
        }

        [HttpGet("GetCarFeatureDetail/{id}")]
        public async Task<IActionResult> GetCarFeatureDetail(int id)
        {
            var values = await _Mediator.Send(new GetCarFeatureDetailQuery(id));
            return Ok(values);
        }        
    }
}
