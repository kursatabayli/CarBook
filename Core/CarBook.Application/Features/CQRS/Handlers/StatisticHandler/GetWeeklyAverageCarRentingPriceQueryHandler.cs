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
    public class GetWeeklyAverageCarRentingPriceQueryHandler : IRequestHandler<GetWeeklyAverageCarRentingPriceQuery, GetWeeklyAverageCarRentingPriceQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetWeeklyAverageCarRentingPriceQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetWeeklyAverageCarRentingPriceQueryResult> Handle(GetWeeklyAverageCarRentingPriceQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetWeeklyAverageCarRentingPrice();
            return new GetWeeklyAverageCarRentingPriceQueryResult
            {
                W_AvgCarR_Price = value,
            };
        }
    }
}
