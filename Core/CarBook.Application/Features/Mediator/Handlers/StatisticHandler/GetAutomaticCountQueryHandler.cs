﻿using CarBook.Application.Features.Mediator.Queries.StatisticQuery;
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
    public class GetAutomaticCountQueryHandler : IRequestHandler<GetAutomaticCountQuery, GetAutomaticCountQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAutomaticCountQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAutomaticCountQueryResult> Handle(GetAutomaticCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAutomaticCount();
            return new GetAutomaticCountQueryResult
            {
                AutomaticCount = value,
            };
        }
    }
}
