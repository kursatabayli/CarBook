using CarBook.Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.FeatureQueries
{
	public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
	{
	}
}
