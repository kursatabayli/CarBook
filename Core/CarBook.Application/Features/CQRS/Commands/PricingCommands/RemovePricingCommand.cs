using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.PricingCommands
{
	public class RemovePricingCommand : IRequest
	{
		public int Id { get; set; }

		public RemovePricingCommand(int id)
		{
			Id = id;
		}
	}
}
