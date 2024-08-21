using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CategoryCommands
{
	public class UpdateCategoryCommand : IRequest
    {
		public int CategoryID { get; set; }
		public string Name { get; set; }
	}
}
