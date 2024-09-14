using CarBook.Application.Features.CQRS.Queries.TestimonialQueries;
using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
	public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		private readonly IRepository<Testimonial> _repository;

		public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetTestimonialByIdQueryResult
			{
				TestimonialID = values.TestimonialID,
				Name = values.Name,
				Title = values.Title,
				Comment = values.Comment,
				ImageUrl = values.ImageUrl,
			};
		}
	}
}
