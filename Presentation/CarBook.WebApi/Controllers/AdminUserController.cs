using CarBook.Application.Features.CQRS.Commands.UserCommands;
using CarBook.Application.Features.CQRS.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminUserController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminUserController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> User()
        {
            var value = await _Mediator.Send(new GetUserInfoChangeQuery());
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Kullanıcı bilgileri başarıyla güncellendi");
        }
    }
}
