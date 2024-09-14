using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvaliableChangeToTrueCommand:IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvaliableChangeToTrueCommand(int id)
        {
            Id = id;
        }
    }
}
