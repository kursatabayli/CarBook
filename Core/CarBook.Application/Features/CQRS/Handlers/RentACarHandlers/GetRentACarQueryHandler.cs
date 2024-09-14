using CarBook.Application.Features.CQRS.Queries.RentACarQueries;
using CarBook.Application.Features.CQRS.Results.RentACarResults;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarID = x.CarID,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,
                Amount = x.Car.CarPricings.Where(y => y.PricingID == 1).First().Amount,
            }).ToList();
        }
    }
}
