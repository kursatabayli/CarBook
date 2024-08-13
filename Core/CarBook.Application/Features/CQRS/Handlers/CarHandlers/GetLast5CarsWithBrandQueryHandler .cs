using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetLast5CarsWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public List<GetLast5CarsWithBrandQueryResult> Handle()
		{
			var values = _repository.GetLast5CarsWithBrands();
			return values.Select(x => new GetLast5CarsWithBrandQueryResult
			{
                CarID = x.CarID,
                BrandID = x.BrandID,
				BrandName = x.Brand.Name,
				BigImageUrl = x.BigImageUrl,
				CoverImageUrl = x.CoverImageUrl,
				Fuel = x.Fuel,
				Km = x.Km,
				Luggage = x.Luggage,
				Model = x.Model,
				Seat = x.Seat,
				Transmission = x.Transmission,

			}).ToList();
		}
	}
}
