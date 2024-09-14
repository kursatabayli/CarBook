using CarBook.Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.PricingQueries
{
	public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
	{
		public int Id { get; set; }

		public GetPricingByIdQuery(int id)
		{
			Id = id;
		}
	}
}
