using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
	public class RemoveCarCommand:IRequest
	{
		public int Id { get; set; }

		public RemoveCarCommand(int id)
		{
			Id = id;
		}
	}
}
