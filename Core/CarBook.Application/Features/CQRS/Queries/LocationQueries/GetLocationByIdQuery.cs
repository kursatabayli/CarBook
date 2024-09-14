using CarBook.Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.LocationQueries
{
	public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
	{
		public int Id { get; set; }

		public GetLocationByIdQuery(int id)
		{
			Id = id;
		}
	}
}
