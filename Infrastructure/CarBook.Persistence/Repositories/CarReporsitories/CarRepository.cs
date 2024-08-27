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

        public async Task<Car> GetCarDetailsById(int id)
        {
            var values = await _context.Cars
            .Include(x => x.Brand)
            .Include(y => y.CarFuel)
            .Include(z => z.CarTransmission)
            .Include(q => q.CarLuggage)
            .Include(t=>t.CarFeatures)
            .ThenInclude(a=>a.Feature)
            .Include(b=>b.CarDescriptions)
            .Where(c => c.CarID == id)
            .SingleOrDefaultAsync();
            return values;
        }

        public List<Car> GetCarsListWithBrandAndOtherFeatures()
        {
            var values = _context.Cars
                .Include(x => x.Brand)
                .Include(y => y.CarFuel)
                .Include(z => z.CarTransmission)
                .Include(q => q.CarLuggage)
                .ToList();
            return values;
        }


        public List<Car> GetLast5CarsWithBrands()
        {
			var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
			return values;
        }
    }
}
