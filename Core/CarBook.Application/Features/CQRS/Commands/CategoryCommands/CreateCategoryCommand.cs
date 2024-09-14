using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
	public class CreateCategoryCommand : IRequest
    {
		public string Name { get; set; }
	}
}
