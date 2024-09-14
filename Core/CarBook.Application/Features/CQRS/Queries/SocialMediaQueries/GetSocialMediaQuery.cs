using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.SocialMediaQueries
{
	public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
	{
	}
}
