using CarBook.Application.Features.CQRS.Queries.ReviewQueries;
using CarBook.Application.Features.CQRS.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ReviewHandlers
{
	public class GetReviewsByCarIdQueryHandler : IRequestHandler<GetReviewsByCarIdQuery, List<GetReviewsByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;

		public GetReviewsByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewsByCarIdQueryResult>> Handle(GetReviewsByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetReviewsByCarID(request.Id);
			return values.Select(x => new GetReviewsByCarIdQueryResult
			{
				CarID = x.CarID,
				ReviewID = x.ReviewID,
				CustomerName = x.CustomerName,
				Comment = x.Comment,
				ReviewDate = x.ReviewDate,
				CustomerImage = x.CustomerImage,
				RaytingValue = x.RaytingValue,

			}).ToList();
		}
	}
}
