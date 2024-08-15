using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        int GetAuthorCount();
        int GetAutomaticCount();
        int GetBlogCount();
        int GetBrandCount();
        int GetCarCount();
        int GetTestimonialCount();
        (string BrandName, int Count) GetHighestCarBrand();
        int GetLocationCount();
        decimal GetDailyAverageCarRentingPrice();
        decimal GetMonthlyAverageCarRentingPrice();
        decimal GetWeeklyAverageCarRentingPrice();
        //string GetMostExpensiveCar();
        //string GetCheapestCar();

        
    }
}
