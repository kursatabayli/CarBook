﻿using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
	public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new Testimonial
			{
				Name = request.Name,
				Title = request.Title,
				Comment = request.Comment,
				ImageUrl = request.ImageUrl,
			});
		}
	}
}
