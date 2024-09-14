using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.ServiceCommands
{
	public class RemoveServiceCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveServiceCommand(int id)
		{
			Id = id;
		}
	}
}
