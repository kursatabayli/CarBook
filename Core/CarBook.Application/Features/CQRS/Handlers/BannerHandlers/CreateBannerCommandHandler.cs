﻿using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class CreateBannerCommandHandler:IRequestHandler<CreateBannerCommand>
	{
		private readonly IRepository<Banner> _repository;
		public CreateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Banner
            {
                Title = request.Title,
                Description = request.Description,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl,
                BannerImageUrl = request.BannerImageUrl,
            });
        }
    }
}
