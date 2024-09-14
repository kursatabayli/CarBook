using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.LocationCommands
{
	public class CreateLocationCommand : IRequest
	{
		public string Name { get; set; }
        public string Maps { get; set; }

    }
}
