using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.PricingInterfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingDayWeekMonthByIdQueryHandler : IRequestHandler<GetCarPricingDayWeekMonthByIdQuery, GetCarPricingDayWeekMonthByIdQueryResult>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingDayWeekMonthByIdQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarPricingDayWeekMonthByIdQueryResult> Handle(GetCarPricingDayWeekMonthByIdQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingByCarAndPricingId(request.Id);

			var result = values
				.GroupBy(y => new { y.CarID})
				.Select(g => new GetCarPricingDayWeekMonthByIdQueryResult
				{
					CarPricingID = g.First().CarPricingID,
					CarID = g.Key.CarID,
					PricingID = g.First().PricingID,
					PricingName = g.First().Pricing.Name,
					BrandAndModel = g.First().Car.Brand.Name + " " + g.First().Car.Model,
					CoverImageUrl = g.First().Car.CoverImageUrl,
					DailyPrice = g.Where(x => x.PricingID == 1).Select(x => x.Amount).FirstOrDefault(),
					WeeklyPrice = g.Where(x => x.PricingID == 2).Select(x => x.Amount).FirstOrDefault(),
					MonthlyPrice = g.Where(x => x.PricingID == 3).Select(x => x.Amount).FirstOrDefault()

				}).FirstOrDefault();

			return result;
		}
	}
}
