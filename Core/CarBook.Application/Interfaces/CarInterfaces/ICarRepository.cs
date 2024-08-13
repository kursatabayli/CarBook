using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
	public interface ICarRepository
	{
		List<Car> GetCarsListWithBrands();
		List<Car> GetLast5CarsWithBrands();
	}
}
