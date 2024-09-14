using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class UpdateContactCommandHandler:IRequestHandler<UpdateContactCommand>
	{
		private readonly IRepository<Contact> _repository;

		public UpdateContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ContactID);
            values.Name = request.Name;
            values.Email = request.Email;
            values.Subject = request.Subject;
            values.Message = request.Message;
            values.SendDate = request.SendDate;
            await _repository.UpdateAsync(values);
        }
    }
}
