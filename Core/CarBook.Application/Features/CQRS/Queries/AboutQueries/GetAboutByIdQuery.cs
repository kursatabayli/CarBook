using CarBook.Application.Features.CQRS.Results.AboutResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
	public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
    {
		public int Id { get; set; }
		public GetAboutByIdQuery(int id)
		{
			Id = id;
		}

	}
}
