using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
	public class UpdateBrandCommand : IRequest
    {
		public int BrandID { get; set; }
		public string Name { get; set; }
	}
}
