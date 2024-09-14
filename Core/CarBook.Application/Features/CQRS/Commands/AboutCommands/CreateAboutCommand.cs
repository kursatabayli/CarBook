using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
	public class CreateAboutCommand:IRequest
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}
