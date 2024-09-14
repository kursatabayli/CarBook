using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public BannersController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _Mediator.Send(new GetBannerQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _Mediator.Send(new GetBannerByIdQuery(id));
            return Ok(values);
        }
    }
}
