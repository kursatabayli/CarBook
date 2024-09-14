using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.FeatureCommands
{
	public class UpdateFeatureCommand : IRequest
	{
		public int FeatureID { get; set; }
		public string Name { get; set; }
	}
}
