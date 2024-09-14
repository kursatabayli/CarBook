using CarBook.Application.Features.CQRS.Queries.FeatureQueries;
using CarBook.Application.Features.CQRS.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
	public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
	{
		private readonly IRepository<Feature> _repository;

		public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetFeatureByIdQueryResult
			{
				FeatureID = values.FeatureID,
				Name = values.Name,
			};
		}
	}
}
