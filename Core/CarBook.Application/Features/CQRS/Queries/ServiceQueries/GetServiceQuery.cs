using CarBook.Application.Features.CQRS.Results.ServiceResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.ServiceQueries
{
	public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
	{
	}
}
