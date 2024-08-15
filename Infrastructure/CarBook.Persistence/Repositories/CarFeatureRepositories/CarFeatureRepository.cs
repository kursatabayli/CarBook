using CarBook.Application.Interfaces.CarFeaturesInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarFeature> CarFeatureDetail(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarID == id).Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Car).ThenInclude(x => x.CarTransmission).Include(x => x.Car).ThenInclude(x => x.CarFuel).Include(x => x.Car).ThenInclude(x => x.CarLuggage).Include(x => x.Feature).ToList();
            return values;
        }

        void ICarFeatureRepository.ChangeCarFeatureAvaliableFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        void ICarFeatureRepository.ChangeCarFeatureAvaliableTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }
    }
}
