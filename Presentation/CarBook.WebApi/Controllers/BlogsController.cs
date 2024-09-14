using CarBook.Application.Features.CQRS.Commands.BlogCommands;
using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public BlogsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _Mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var values = await _Mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Blog Başarıyla Eklendi");
        }

        [HttpPut] 
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _Mediator.Send(command);
            return Ok("Blog Başarıyla Güncellendi");
        }

        [HttpGet("GetLast3BlogsWithAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthorsList()
        {
            var values = await _Mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(values);
        }

        [HttpGet("GetAllBlogsWithAuthorsList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorsList()
        {
            var values = await _Mediator.Send(new GetAllBlogsWithAuthorsQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorByBlogIdList/{id}")]
        public async Task<IActionResult> GetAuthorByBlogIdList(int id)
        {
            var values = await _Mediator.Send(new GetBlogAuthorByIdQuery(id));
            return Ok(values);
        }
    }
}
