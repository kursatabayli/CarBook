using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
	public class GetBannerQueryHandler:IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
	{
		private readonly IRepository<Banner> _repository;
		public GetBannerQueryHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}
        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                Description = x.Description,
                Title = x.Title,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl,
                BannerImageUrl = x.BannerImageUrl,
            }).ToList();
        }
    }
}
