using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBrandsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminBrandsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Marka Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _Mediator.Send(new RemoveBrandCommand(id));
            return Ok("Marka Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Marka Bilgisi Güncellendi");
        }
    }
}
