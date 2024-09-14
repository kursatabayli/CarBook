using CarBook.Application.Features.CQRS.Results.ServiceResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.ServiceQueries
{
	public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
	{
		public int Id { get; set; }

		public GetServiceByIdQuery(int id)
		{
			Id = id;
		}
	}
}
