using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarResults
{
    public class GetCarDetaisByIdQueryResult
    {
        public int CarID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string TransmissionType { get; set; }
        public byte Seat { get; set; }
        public string LuggageType { get; set; }
        public string FuelType { get; set; }
        public string BigImageUrl { get; set; }
        public List<bool> Available { get; set; }
		public List<string> FeatureName { get; set; }
        public string Details { get; set; }
	}
}
