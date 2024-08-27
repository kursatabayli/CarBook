using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ReviewCommands
{
	public class RemoveReviewCommand:IRequest
	{
        public int Id { get; set; }

		public RemoveReviewCommand(int id)
		{
			Id = id;
		}
	}
}
