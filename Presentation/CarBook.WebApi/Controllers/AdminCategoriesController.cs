using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminCategoriesController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public AdminCategoriesController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Kategori Bilgisi Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _Mediator.Send(new RemoveCategoryCommand(id));
            return Ok("Kategori Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Kategori Bilgisi Güncellendi");
        }
    }
}
