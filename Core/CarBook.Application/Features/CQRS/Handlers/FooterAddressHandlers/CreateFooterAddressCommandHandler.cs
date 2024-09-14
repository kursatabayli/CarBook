using CarBook.Application.Features.CQRS.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
	{
		private readonly IRepository<FooterAddress> _repository;

		public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new FooterAddress
			{
				Address = request.Address,
				Description = request.Description,
				Email = request.Email,
				Phone = request.Phone,
			});
		}
	}
}
