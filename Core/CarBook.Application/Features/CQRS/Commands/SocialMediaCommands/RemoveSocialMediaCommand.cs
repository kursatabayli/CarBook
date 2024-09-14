using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.SocialMediaCommands
{
	public class RemoveSocialMediaCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveSocialMediaCommand(int id)
		{
			Id = id;
		}
	}
}
