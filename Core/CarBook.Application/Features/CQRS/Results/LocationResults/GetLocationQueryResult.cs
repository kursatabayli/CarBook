namespace CarBook.Application.Features.CQRS.Results.LocationResults
{
	public class GetLocationQueryResult
	{
		public int LocationID { get; set; }
		public string Name { get; set; }
        public string Maps { get; set; }

    }
}
