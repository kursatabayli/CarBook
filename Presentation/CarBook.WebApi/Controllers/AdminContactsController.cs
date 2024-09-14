using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminContactsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminContactsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _Mediator.Send(new GetContactQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _Mediator.Send(new GetContactByIdQuery(id));
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _Mediator.Send(new RemoveContactCommand(id));
            return Ok("İletişim Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _Mediator.Send(command);
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}
