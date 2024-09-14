using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.CarPricingResults
{
	public class GetCarPricingsByCarIdQueryResult
	{
		public int CarID { get; set; }
		public string PricingName { get; set; }
		public string BrandAndModel { get; set; }
		public string CoverImageUrl { get; set; }
		public decimal DailyPrice { get; set; }
		public decimal WeeklyPrice { get; set; }
		public decimal MonthlyPrice { get; set; }
	}
}
