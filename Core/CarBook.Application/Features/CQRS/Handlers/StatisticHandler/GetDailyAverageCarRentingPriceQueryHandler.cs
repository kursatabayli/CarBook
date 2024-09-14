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
    public class GetDailyAverageCarRentingPriceQueryHandler : IRequestHandler<GetDailyAverageCarRentingPriceQuery, GetDailyAverageCarRentingPriceQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetDailyAverageCarRentingPriceQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetDailyAverageCarRentingPriceQueryResult> Handle(GetDailyAverageCarRentingPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetDailyAverageCarRentingPrice();
            return new GetDailyAverageCarRentingPriceQueryResult
            {
                D_AvgCarR_Price = value,
            };
        }
    }
}
