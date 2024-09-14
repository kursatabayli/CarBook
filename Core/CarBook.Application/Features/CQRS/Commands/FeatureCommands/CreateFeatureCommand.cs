using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.FeatureCommands
{
	public class CreateFeatureCommand : IRequest
	{
		public string Name { get; set; }
	}
}
