using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	internal class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.ReviewID);
			values.CarID = request.CarID;
			values.CustomerName = request.CustomerName;
			values.Comment = request.Comment;
			values.CustomerImage = request.CustomerImage;
			values.RaytingValue = request.RaytingValue;
			values.ReviewDate = request.ReviewDate;
			await _repository.UpdateAsync(values);
		}
	}
}
