﻿using CarBook.Application.Features.CQRS.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
	public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
	{
		private readonly IRepository<Location> _repository;

		public CreateLocationCommandHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateLocationCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new Location
			{
				Name = request.Name,
				Maps = request.Maps,
			});
		}
	}
}
