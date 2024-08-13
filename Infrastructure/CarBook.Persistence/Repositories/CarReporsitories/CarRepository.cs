using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarReporsitories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;

		public CarRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<Car> GetCarsListWithBrands()
		{
			var values = _context.Cars.Include(x => x.Brand).ToList();
			return values;
		}

        public List<Car> GetLast5CarsWithBrands()
        {
			var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
			return values;
        }
    }
}
