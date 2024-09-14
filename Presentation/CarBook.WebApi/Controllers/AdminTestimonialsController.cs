using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminTestimonialsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminTestimonialsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _Mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Referans Bilgisi Güncellendi");
        }
    }
}
