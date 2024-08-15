using CarBook.Application.Features.Mediator.Queries.StatisticQuery;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandler
{
    public class GetHighestCarBrandCountQueryHandler : IRequestHandler<GetHighestCarBrandQuery, GetHighestCarBrandQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetHighestCarBrandCountQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetHighestCarBrandQueryResult> Handle(GetHighestCarBrandQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetHighestCarBrand();
            return new GetHighestCarBrandQueryResult
            {
                HighestBrandName = value.BrandName,
                HighestBrandCount = value.Count,
            };
        }
    }
}
