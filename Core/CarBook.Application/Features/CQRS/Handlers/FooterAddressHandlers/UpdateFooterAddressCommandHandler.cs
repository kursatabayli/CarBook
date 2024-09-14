using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}
		public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.FooterAddressID);
			values.Description = request.Description;
			values.Address = request.Address;
			values.Phone = request.Phone;
			values.Email = request.Email;
			await _repository.UpdateAsync(values);
		}
	}
}
