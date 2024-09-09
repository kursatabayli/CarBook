using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingsByCarIdQuery:IRequest<GetCarPricingsByCarIdQueryResult>
	{
        public int Id { get; set; }

		public GetCarPricingsByCarIdQuery(int id)
		{
			Id = id;
		}
	}
}
