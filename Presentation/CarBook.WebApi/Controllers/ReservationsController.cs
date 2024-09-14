using CarBook.Application.Features.CQRS.Commands.ReservationCommands;
using CarBook.Application.Features.CQRS.Queries.ReservationQueries;
using CarBook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public ReservationsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Rezervasyon Başarıyla Oluşturuldu");
        }

        [HttpGet("GetAvailableCars")]
        public async Task<ActionResult<List<GetAvailableCarsQueryResult>>> GetAvailableCars(
            [FromQuery] DateTime pickUpDate,
            [FromQuery] DateTime dropOffDate,
            [FromQuery] TimeSpan pickUpTime,
            [FromQuery] TimeSpan dropOffTime,
            [FromQuery] int locationID)
        {
            var query = new GetAvailableCarsQuery
            {
                PickUpDate = pickUpDate,
                DropOffDate = dropOffDate,
                PickUpTime = pickUpTime,
                DropOffTime = dropOffTime,
                LocationID = locationID
            };

            var availableCars = await _Mediator.Send(query);

            if (availableCars == null || availableCars.Count == 0)
                return NotFound("Belirtilen kriterlere göre müsait araç bulunamadı.");

            return Ok(availableCars);
        }
    }
}
