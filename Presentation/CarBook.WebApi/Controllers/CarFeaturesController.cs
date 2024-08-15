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
        
        [HttpGet("MakeitFalse")]
        public async Task<IActionResult> UpdateCarFeatureAvaliableChangeToFalseCommand(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaliableChangeToFalseCommand(id));
            return Ok("Güncelleme yapıldı");
        }
        
        [HttpGet("MakeitTrue")]
        public async Task<IActionResult> UpdateCarFeatureAvaliableChangeToTrueCommand(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaliableChangeToTrueCommand(id));
            return Ok("Güncelleme yapıldı");
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateCarFeature(CreateCarFeatureCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok("Servis Bilgisi Eklendi");
        //}

        //[HttpDelete]
        //public async Task<IActionResult> RemoveCarFeature(int id)
        //{
        //    await _mediator.Send(new RemoveCarFeatureCommand(id));
        //    return Ok("Servis Bilgisi Silindi");
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateCarFeature(UpdateCarFeatureCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok("Servis Bilgisi Güncellendi");
        //}
    }
}
