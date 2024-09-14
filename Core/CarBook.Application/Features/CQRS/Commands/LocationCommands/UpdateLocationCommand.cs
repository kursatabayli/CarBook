using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.LocationCommands
{
	public class UpdateLocationCommand : IRequest
	{
		public int LocationID { get; set; }
		public string Name { get; set; }
		public string Maps { get; set; }
    }
}
