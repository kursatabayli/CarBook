﻿using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BannerCommands
{
	public class RemoveBannerCommand : IRequest
    {
		public int Id { get; set; }

		public RemoveBannerCommand(int id)
		{
			Id = id;
		}
	}
}
