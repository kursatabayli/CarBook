﻿using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannersController : ControllerBase
	{
		private readonly CreateBannerCommandHandler _createBannerCommandHandler;
		private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
		private readonly GetBannerQueryHandler _getBannerQueryHandler;
		private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
		private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

		public BannersController(CreateBannerCommandHandler createBannerCommandHandler,
			GetBannerByIdQueryHandler getBannerByIdQueryHandler,
			GetBannerQueryHandler getBannerQueryHandler,
			RemoveBannerCommandHandler removeBannerCommandHandler,
			UpdateBannerCommandHandler updateBannerCommandHandler)
		{
			_createBannerCommandHandler = createBannerCommandHandler;
			_getBannerByIdQueryHandler = getBannerByIdQueryHandler;
			_getBannerQueryHandler = getBannerQueryHandler;
			_removeBannerCommandHandler = removeBannerCommandHandler;
			_updateBannerCommandHandler = updateBannerCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> BannerList()
		{
			var values = await _getBannerQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBanner(int id)
		{
			var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
		{
			await _createBannerCommandHandler.Handle(command);
			return Ok("Banner Eklendi");
		}

		[HttpDelete]
		public async Task<IActionResult> RemoveBanner(int id)
		{
			await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
			return Ok("Banner Silindi");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
		{
			await _updateBannerCommandHandler.Handle(command);
			return Ok("Banner Güncellendi");
		}
	}
}
