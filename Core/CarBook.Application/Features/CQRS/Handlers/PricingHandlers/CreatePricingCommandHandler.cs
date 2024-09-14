using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
	public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
	{
		private readonly IRepository<Pricing> _repository;

		public CreatePricingCommandHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreatePricingCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new Pricing
			{
				Name = request.Name,
			});
		}
	}
}
