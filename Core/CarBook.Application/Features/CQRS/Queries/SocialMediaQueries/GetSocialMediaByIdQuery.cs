using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.SocialMediaQueries
{
	public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
	{
		public int Id { get; set; }

		public GetSocialMediaByIdQuery(int id)
		{
			Id = id;
		}
	}
}
