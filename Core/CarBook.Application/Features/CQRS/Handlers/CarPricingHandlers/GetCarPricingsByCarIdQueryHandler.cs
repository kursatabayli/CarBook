using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.PricingInterfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
	public class GetCarPricingsByCarIdQueryHandler : IRequestHandler<GetCarPricingsByCarIdQuery, GetCarPricingsByCarIdQueryResult>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingsByCarIdQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarPricingsByCarIdQueryResult> Handle(GetCarPricingsByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingByCarAndPricingIdAsync(request.Id);

            return values
				.GroupBy(y => new { y.CarID})
				.Select(g => new GetCarPricingsByCarIdQueryResult
				{
					CarID = g.Key.CarID,
					PricingName = g.First().Pricing.Name,
					BrandAndModel = g.First().Car.Brand.Name + " " + g.First().Car.Model,
					CoverImageUrl = g.First().Car.CoverImageUrl,
					DailyPrice = g.Where(x => x.PricingID == 1).Select(x => x.Amount).FirstOrDefault(),
					WeeklyPrice = g.Where(x => x.PricingID == 2).Select(x => x.Amount).FirstOrDefault(),
					MonthlyPrice = g.Where(x => x.PricingID == 3).Select(x => x.Amount).FirstOrDefault()

				}).FirstOrDefault()!;

			
		}
	}
}
