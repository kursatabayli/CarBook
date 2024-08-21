using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CategoryCommands
{
	public class CreateCategoryCommand : IRequest
    {
		public string Name { get; set; }
	}
}
