using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
	public class RemoveCategoryCommand : IRequest
    {
		public int Id { get; set; }

		public RemoveCategoryCommand(int id)
		{
			Id = id;
		}
	}
}
