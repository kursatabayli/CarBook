using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class RemoveCarPricingCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveCarPricingCommand(int id)
        {
            Id = id;
        }
    }
}
