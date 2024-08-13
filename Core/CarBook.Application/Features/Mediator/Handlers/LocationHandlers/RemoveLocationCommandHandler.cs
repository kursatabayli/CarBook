using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
	{
		private readonly IRepository<Feature> _repository;

		public RemoveLocationCommandHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}
