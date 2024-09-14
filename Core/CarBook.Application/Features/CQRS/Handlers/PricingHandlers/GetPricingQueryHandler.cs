using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using CarBook.Application.Features.CQRS.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
	public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
	{
		private readonly IRepository<Pricing> _repository;

		public GetPricingQueryHandler(IRepository<Pricing> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetPricingQueryResult
			{
				PricingID = x.PricingID,
				Name = x.Name,
			}).ToList();
		}
	}
}
