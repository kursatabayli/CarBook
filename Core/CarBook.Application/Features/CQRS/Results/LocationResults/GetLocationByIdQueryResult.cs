namespace CarBook.Application.Features.CQRS.Results.LocationResults
{
	public class GetLocationByIdQueryResult
	{
		public int LocationID { get; set; }
		public string Name { get; set; }
        public string Maps { get; set; }

    }
}
