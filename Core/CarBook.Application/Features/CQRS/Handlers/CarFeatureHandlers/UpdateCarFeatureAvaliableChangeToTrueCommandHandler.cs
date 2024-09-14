using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.CarFeaturesInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvaliableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvaliableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvaliableChangeToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvaliableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvaliableTrue(request.Id);

        }
    }
}
