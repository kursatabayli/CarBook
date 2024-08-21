using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
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
	public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQueryResult>
	{
		private readonly IRepository<Review> _repository;

		public GetReviewByIdQueryHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}
		public async Task<GetReviewByIdQueryResult> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetReviewByIdQueryResult
			{
				ReviewID = values.ReviewID,
				CarID = values.CarID,
				CustomerName = values.CustomerName,
				Comment = values.Comment,
				RaytingValue = values.RaytingValue,
				CustomerImage = values.CustomerImage,
				ReviewDate = values.ReviewDate,
			};
		}
	}
}
