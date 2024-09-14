using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.FeatureCommands
{
	public class RemoveFeatureCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveFeatureCommand(int id)
		{
			Id = id;
		}
	}
}
