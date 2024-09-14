using CarBook.Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.BrandQueries
{
	public class GetBrandByIdQuery : IRequest<GetBrandByIdQueryResult>
    {
		public int Id { get; set; }
		public GetBrandByIdQuery(int id)
		{
			Id = id;
		}
	}
}
