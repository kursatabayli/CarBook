using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.PricingInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarsQueryHandler : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarsQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();

            return values
                .GroupBy(x => x.CarID)
                .Select(g => new GetCarPricingWithCarsQueryResult
                {
                    CarID = g.Key,
                    PricingName = g.First().Pricing.Name,
                    BrandName = g.First().Car.Brand.Name,
                    Model = g.First().Car.Model,
                    CoverImageUrl = g.First().Car.CoverImageUrl,
                    Amount = g.First().Amount,
                    DailyPrice = g.Where(x=>x.PricingID==1).Select(x=>x.Amount).FirstOrDefault(),
                    WeeklyPrice = g.Where(x => x.PricingID == 2).Select(x => x.Amount).FirstOrDefault(),
                    MonthlyPrice = g.Where(x => x.PricingID == 3).Select(x => x.Amount).FirstOrDefault(),
                }).ToList();
        }
    }
}
