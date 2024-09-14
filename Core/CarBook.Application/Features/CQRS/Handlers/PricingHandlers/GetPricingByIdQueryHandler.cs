using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using CarBook.Application.Features.CQRS.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
	public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
	{
		private readonly IRepository<Pricing> _repository;

		public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetPricingByIdQueryResult
			{
				PricingID = values.PricingID,
				Name = values.Name,
			};
		}
	}
}
