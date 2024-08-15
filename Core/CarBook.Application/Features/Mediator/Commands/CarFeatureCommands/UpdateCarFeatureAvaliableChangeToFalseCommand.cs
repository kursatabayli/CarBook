using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvaliableChangeToFalseCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvaliableChangeToFalseCommand(int id)
        {
            Id = id;
        }
    }
}
