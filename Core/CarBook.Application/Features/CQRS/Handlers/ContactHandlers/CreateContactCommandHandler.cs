using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class CreateContactCommandHandler:IRequestHandler<CreateContactCommand>
	{
		private readonly IRepository<Contact> _repository;

		public CreateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Contact
            {
                Name = request.Name,
                Email = request.Email,
                Message = request.Message,
                Subject = request.Subject,
                SendDate = DateTime.UtcNow,
            });
        }
    }
}
