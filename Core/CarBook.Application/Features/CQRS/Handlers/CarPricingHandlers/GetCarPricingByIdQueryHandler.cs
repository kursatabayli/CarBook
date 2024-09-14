using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
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
    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingByIdQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCarPricingByIdQueryResult
            {
                CarPricingID = values.CarPricingID,
                CarID = values.CarID,
                PricingID = values.PricingID,
                Amount = values.Amount,
                
            };
        }

    }
}
