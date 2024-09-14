using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public ContactsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _Mediator.Send(command);
            return Ok("İletişim Bilgisi Eklendi");
        }
    }
}