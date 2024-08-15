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
    public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetLocationCountQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = value,
            };
        }
    }
}
