using CarBook.Application.Features.CQRS.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ReviewQueries
{
	public class GetReviewByIdQuery:IRequest<GetReviewByIdQueryResult>
	{
        public int Id { get; set; }

		public GetReviewByIdQuery(int id)
		{
			Id = id;
		}
	}
}
