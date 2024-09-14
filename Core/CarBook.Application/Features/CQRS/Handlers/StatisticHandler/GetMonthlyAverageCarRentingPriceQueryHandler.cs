using CarBook.Application.Features.CQRS.Queries.StatisticQuery;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.StatisticHandler
{
    public class GetMonthlyAverageCarRentingPriceQueryHandler : IRequestHandler<GetMonthlyAverageCarRentingPriceQuery, GetMonthlyAverageCarRentingPriceQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetMonthlyAverageCarRentingPriceQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetMonthlyAverageCarRentingPriceQueryResult> Handle(GetMonthlyAverageCarRentingPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetMonthlyAverageCarRentingPrice();
            return new GetMonthlyAverageCarRentingPriceQueryResult
            {
                M_AvgCarR_Price = value,
            };
        }
    }
}
