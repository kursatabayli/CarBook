using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.TestimonialQueries
{
	public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
	{
	}
}
