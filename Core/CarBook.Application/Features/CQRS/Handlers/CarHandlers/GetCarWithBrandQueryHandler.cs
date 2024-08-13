using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetCarWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public List<GetCarWithBrandQueryResult> Handle()
		{
			var values = _repository.GetCarsListWithBrands();
			return values.Select(x => new GetCarWithBrandQueryResult
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
