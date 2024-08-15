using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingDayWeekMonthByIdQueryResult
	{
		public int CarPricingID { get; set; }
		public int CarID { get; set; }
		public int PricingID { get; set; }
		public string PricingName { get; set; }
		public string BrandAndModel { get; set; }
		public string CoverImageUrl { get; set; }
		public decimal DailyPrice { get; set; }
		public decimal WeeklyPrice { get; set; }
		public decimal MonthlyPrice { get; set; }
	}
}
