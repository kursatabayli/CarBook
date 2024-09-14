using CarBook.Application.Features.CQRS.Queries.SocialMediaQueries;
using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
	{
		private readonly IRepository<SocialMedia> _repository;

		public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetSocialMediaQueryResult
			{
				SocialMediaID = x.SocialMediaID,
				Icon = x.Icon,
				Name = x.Name,
				Url = x.Url,
			}).ToList();
		}
	}
}
