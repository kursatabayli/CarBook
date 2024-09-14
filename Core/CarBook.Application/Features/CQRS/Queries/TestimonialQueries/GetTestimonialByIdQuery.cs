using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.TestimonialQueries
{
	public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
	{
		public int Id { get; set; }

		public GetTestimonialByIdQuery(int id)
		{
			Id = id;
		}
	}
}
