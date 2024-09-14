using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
	{
		private readonly IRepository<Feature> _repository;

		public UpdateFeatureCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.FeatureID);
			values.Name = request.Name;
			await _repository.UpdateAsync(values);
		}
	}
}
