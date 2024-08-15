using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces.CarFeaturesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureDetailQueryHandler : IRequestHandler<GetCarFeatureDetailQuery, List<GetCarFeatureDetailQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureDetailQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureDetailQueryResult>> Handle(GetCarFeatureDetailQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.CarFeatureDetail(request.Id);
            return values.Select(x => new GetCarFeatureDetailQueryResult
            {
                CarID = x.CarID,
                CarFeatureID = x.CarFeatureID,
                BrandName = x.Car.Brand.Name,
                Model = x.Car.Model,
                Km = x.Car.Km,
                FuelType = x.Car.CarFuel.FuelType,
                LuggageType = x.Car.CarLuggage.LuggageType,
                TransmissionType = x.Car.CarTransmission.TransmissionType,
                Seat = x.Car.Seat,
                FeatureID = x.FeatureID,
                Available = x.Available,
                FeatureName = x.Feature.Name,

            }).ToList();
        }
    }
}
