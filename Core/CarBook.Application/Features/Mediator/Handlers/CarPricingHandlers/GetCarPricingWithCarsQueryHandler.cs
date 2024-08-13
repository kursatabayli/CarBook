using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.PricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var values = _repository.GetCarPringWithCars();
            return values.Select(x=> new GetCarPricingWithCarsQueryResult
            {
                CarPricingID = x.CarPricingID,
                Amount = x.Amount,
                BrandName = x.Car.Brand.Name,
                CarID = x.Car.CarID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                PricingID = x.PricingID,
                PricingName=x.Pricing.Name,
            }).ToList();
        }
    }
}
