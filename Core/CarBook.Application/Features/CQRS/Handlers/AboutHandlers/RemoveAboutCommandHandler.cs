﻿using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class RemoveAboutCommandHandler:IRequestHandler<RemoveAboutCommand>
	{
		private readonly IRepository<About> _repository;
		public RemoveAboutCommandHandler(IRepository<About> repository)
		{
			_repository = repository;
		}
        public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
