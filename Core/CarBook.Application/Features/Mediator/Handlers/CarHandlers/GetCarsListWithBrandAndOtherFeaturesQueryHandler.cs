using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarsListWithBrandAndOtherFeaturesQueryHandler:IRequestHandler<GetCarsListWithBrandAndOtherFeaturesQuery, List<GetCarsListWithBrandAndOtherFeaturesQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarsListWithBrandAndOtherFeaturesQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsListWithBrandAndOtherFeaturesQueryResult>> Handle(GetCarsListWithBrandAndOtherFeaturesQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarsListWithBrandAndOtherFeatures();
            return values.Select(x => new GetCarsListWithBrandAndOtherFeaturesQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                CarFuelID = x.CarFuelID,
                FuelType = x.CarFuel.FuelType,
                Km = x.Km,
                CarLuggageID = x.CarLuggageID,
                LuggageType = x.CarLuggage.LuggageType,
                Model = x.Model,
                Seat = x.Seat,
                CarTransmissionID = x.CarTransmissionID,
                TransmissionType = x.CarTransmission.TransmissionType,

            }).ToList();
        }
    }
}
