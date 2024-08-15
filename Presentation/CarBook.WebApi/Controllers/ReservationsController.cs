using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var values = await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon Başarıyla Oluşturuldu");
        }

        //[HttpDelete]
        //public async Task<IActionResult> RemoveReservation(int id)
        //{
        //    await _mediator.Send(new RemoveReservationCommand(id));
        //    return Ok("Servis Bilgisi Silindi");
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        //{
        //    await _mediator.Send(command);
        //    return Ok("Servis Bilgisi Güncellendi");
        //}
    }
}
