using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository :IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public int GetAutomaticCount()
        {
            var value = _context.Cars.Count(x => x.CarTransmissionID == 1);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public (string BrandName, int Count) GetHighestCarBrand()
        {
            var result = _context.Cars
                .GroupBy(x => x.Brand.Name)
                .OrderByDescending(y => y.Count())
                .Select(y => new
                {
                    BrandName = y.Key,
                    Count = y.Count()
                })
                .FirstOrDefault();

            return (result.BrandName, result.Count);
        }


        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
        public decimal GetDailyAverageCarRentingPrice()
        {
            var value = _context.CarPricings.Where(y => y.PricingID == 1).Average(x => x.Amount);
            return value;
        }

        public decimal GetWeeklyAverageCarRentingPrice()
        {
            var value = _context.CarPricings.Where(y => y.PricingID == 2).Average(x => x.Amount);
            return value;
        }
        public decimal GetMonthlyAverageCarRentingPrice()
        {
            var value = _context.CarPricings.Where(y => y.PricingID == 3).Average(x => x.Amount);
            return value;
        }

        public int GetTestimonialCount()
        {
            var value = _context.Testimonials.Count();
            return value;
        }

        //public string GetMostExpensiveCar()
        //{
        //    var value = _context.CarPricings.Where(x => x.PricingID == 1).OrderByDescending(y => y.Amount).Select(y => new {  }).FirstOrDefault();
        //    var value2 = _context.Cars.
        //}

        //public string GetCheapestCar()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
