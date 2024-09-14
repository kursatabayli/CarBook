using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
	public class CreateBrandCommand : IRequest
    {
		public string Name { get; set; }
	}
}
