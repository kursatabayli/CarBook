using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeaturesInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> CarFeatureDetail(int id);
        void ChangeCarFeatureAvaliableTrue(int id);
        void ChangeCarFeatureAvaliableFalse(int id);
    }
}
