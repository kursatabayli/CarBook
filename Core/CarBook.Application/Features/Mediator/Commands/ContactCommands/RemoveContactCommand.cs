using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ContactCommands
{
	public class RemoveContactCommand : IRequest
    {
		public int Id { get; set; }

		public RemoveContactCommand(int id)
		{
			Id = id;
		}
	}
}
