using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class RemoveCarPricingCommandHandler : IRequestHandler<RemoveCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public RemoveCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarPricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
