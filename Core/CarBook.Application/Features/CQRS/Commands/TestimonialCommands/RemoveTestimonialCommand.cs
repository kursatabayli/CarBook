using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.TestimonialCommands
{
	public class RemoveTestimonialCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveTestimonialCommand(int id)
		{
			Id = id;
		}
	}
}
