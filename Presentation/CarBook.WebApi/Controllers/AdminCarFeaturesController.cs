using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCarFeaturesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminCarFeaturesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet("MakeitFalse/{id}")]
        public async Task<IActionResult> UpdateCarFeatureAvaliableChangeToFalseCommand(int id)
        {
            await _Mediator.Send(new UpdateCarFeatureAvaliableChangeToFalseCommand(id));
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("MakeitTrue/{id}")]
        public async Task<IActionResult> UpdateCarFeatureAvaliableChangeToTrueCommand(int id)
        {
            await _Mediator.Send(new UpdateCarFeatureAvaliableChangeToTrueCommand(id));
            return Ok("Güncelleme yapıldı");
        }
    }
}
