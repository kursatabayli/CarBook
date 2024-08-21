using CarBook.Application.Features.Mediator.Results.BannerResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BannerQueries
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
