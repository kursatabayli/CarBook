using CarBook.Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.LocationQueries
{
	public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
	{
	}
}
