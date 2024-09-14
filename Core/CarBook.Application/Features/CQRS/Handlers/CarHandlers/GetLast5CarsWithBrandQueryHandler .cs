using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetLast5CarsWithBrandQueryHandler:IRequestHandler<GetLast5CarsWithBrandQuery, List<GetLast5CarsWithBrandQueryResult>>
	{
		private readonly ICarRepository _repository;

		public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

        public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                CarFuelID = x.CarFuelID,
                Km = x.Km,
                CarLuggageID = x.CarLuggageID,
                Model = x.Model,
                Seat = x.Seat,
                CarTransmissionID = x.CarTransmissionID,

            }).ToList();
        }
    }
}
