using CarBook.Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries
{
	public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
		public int Id { get; set; }

		public GetCategoryByIdQuery(int id)
		{
			Id = id;
		}
	}
}
