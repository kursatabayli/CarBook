using CarBook.Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.PricingQueries
{
	public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
	{
	}
}
