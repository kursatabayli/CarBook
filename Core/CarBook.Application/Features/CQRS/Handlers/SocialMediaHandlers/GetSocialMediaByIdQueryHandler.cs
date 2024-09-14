using CarBook.Application.Features.CQRS.Queries.SocialMediaQueries;
using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
	{
		private readonly IRepository<SocialMedia> _repository;

		public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetSocialMediaByIdQueryResult
			{
				SocialMediaID = values.SocialMediaID,
				Name = values.Name,
				Url = values.Url,
				Icon = values.Icon,

			};
		}
	}
}
