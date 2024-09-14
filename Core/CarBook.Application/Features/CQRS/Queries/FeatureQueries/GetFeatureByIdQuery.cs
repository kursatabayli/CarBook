using CarBook.Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.FeatureQueries
{
	public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
	{
		public int Id { get; set; }

		public GetFeatureByIdQuery(int id)
		{
			Id = id;
		}
	}
}
