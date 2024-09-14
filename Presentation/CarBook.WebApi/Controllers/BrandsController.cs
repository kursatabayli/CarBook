using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public BrandsController(IMediator Mediator)
        {
            _Mediator = Mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _Mediator.Send(new GetBrandQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var values = await _Mediator.Send(new GetBrandByIdQuery(id));
            return Ok(values);
        }     
    }
}