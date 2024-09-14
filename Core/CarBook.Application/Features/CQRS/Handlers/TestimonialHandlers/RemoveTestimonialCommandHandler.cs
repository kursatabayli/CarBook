using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
	public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}
		public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.RemoveAsync(value);
		}
	}
}

