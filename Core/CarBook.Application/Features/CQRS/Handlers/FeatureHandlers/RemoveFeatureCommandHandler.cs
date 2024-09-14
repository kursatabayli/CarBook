using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;

		public RemoveFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
