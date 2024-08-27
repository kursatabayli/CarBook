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
	public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, List<GetReviewQueryResult>>
	{
		private readonly IRepository<Review> _repository;

		public GetReviewQueryHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewQueryResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetReviewQueryResult
			{
				ReviewID = x.ReviewID,
				CarID = x.CarID,
				CustomerName = x.CustomerName,
				Comment = x.Comment,
				RaytingValue = x.RaytingValue,
				ReviewDate = x.ReviewDate,
				CustomerImage = x.CustomerImage,
			}).ToList();
		}
	}
}
