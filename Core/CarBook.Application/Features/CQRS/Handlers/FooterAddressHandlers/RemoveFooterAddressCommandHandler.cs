using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
