using CarBook.Application.Features.CQRS.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminReservationsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminReservationsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _Mediator.Send(new GetReservationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var values = await _Mediator.Send(new GetReservationByIdQuery(id));
            return Ok(values);
        }
    }
}
