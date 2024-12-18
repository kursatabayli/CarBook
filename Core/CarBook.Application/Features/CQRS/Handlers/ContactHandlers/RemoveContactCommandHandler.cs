﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class RemoveContactCommandHandler:IRequestHandler<RemoveContactCommand>
	{
		private readonly IRepository<Contact> _repository;

		public RemoveContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

        public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
