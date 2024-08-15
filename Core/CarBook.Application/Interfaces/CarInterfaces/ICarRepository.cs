using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrandAndOtherFeatures();
        List<Car> GetLast5CarsWithBrands();
        Task<Car> GetCarDetailsById(int id);
    }

}
