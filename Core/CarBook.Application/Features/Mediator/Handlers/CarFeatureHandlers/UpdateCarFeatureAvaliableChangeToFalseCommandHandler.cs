using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeaturesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvaliableChangeToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvaliableChangeToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvaliableChangeToFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvaliableChangeToFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvaliableFalse(request.Id);
            
        }
    }
}
