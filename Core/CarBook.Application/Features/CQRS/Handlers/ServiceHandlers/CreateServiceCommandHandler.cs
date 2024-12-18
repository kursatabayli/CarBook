﻿using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
	public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
	{
		private readonly IRepository<Service> _repository;

		public CreateServiceCommandHandler(IRepository<Service> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateServiceCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new Service
			{
				Title = request.Title,
				Description = request.Description,
				IconUrl = request.IconUrl,
			});
		}
	}
}
