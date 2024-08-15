using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureDetailQueryResult
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string Model {  get; set; }
        public string TransmissionType { get; set; }
        public string LuggageType { get; set; }
        public string FuelType { get; set; }
        public int FeatureID { get; set; }
        public int Km { get; set; }
        public int Seat { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }

    }
}
