using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;

		public CreateFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateFeatureCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new Feature
			{
				Name = request.Name,
			});
		}
	}
}
