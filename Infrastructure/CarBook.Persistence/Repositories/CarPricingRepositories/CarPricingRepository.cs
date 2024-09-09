using CarBook.Application.Interfaces.PricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }
		public async Task<List<CarPricing>> GetCarPricingByCarAndPricingIdAsync(int id)
		{
			var values = await _context.CarPricings
								 .Include(x => x.Car).ThenInclude(y => y.Brand)
								 .Include(z => z.Pricing)
								 .Where(x => x.CarID == id)
                                 .ToListAsync();
                
			return values;
		}

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values =  _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).ToList();
            return values;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
