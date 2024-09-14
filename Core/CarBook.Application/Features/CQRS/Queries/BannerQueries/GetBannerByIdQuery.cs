using CarBook.Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.BannerQueries
{
	public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
    {
		public int Id { get; set; }
		public GetBannerByIdQuery(int id)
		{
			Id = id;
		}
	}
}
