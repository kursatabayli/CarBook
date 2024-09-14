using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.PricingCommands
{
	public class CreatePricingCommand : IRequest
	{
		public string Name { get; set; }
	}
}
