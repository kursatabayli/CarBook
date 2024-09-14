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
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly IRepository<CarPricing> _repository;

        public GetCarPricingQueryHandler(IRepository<CarPricing> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarPricingQueryResult
            {
                CarPricingID = x.CarPricingID,
                CarID = x.CarID,
                PricingID = x.PricingID,
                Amount = x.Amount,
                
            }).ToList();
        }
    }
}
