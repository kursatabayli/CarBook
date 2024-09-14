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
    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand>
    {
        private readonly IRepository<CarPricing> _repository;

        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CarPricingID);
            values.CarID = request.CarID;
            values.PricingID = request.PricingID;
            values.Amount = request.Amount;
            await _repository.UpdateAsync(values);
        }
    }
}
