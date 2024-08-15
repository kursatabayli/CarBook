using CarBook.Application.Features.Mediator.Queries.LuggageQueries;
using CarBook.Application.Features.Mediator.Results.LuggageResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LuggageHandlers
{
    public class GetLuggageQueryHandler : IRequestHandler<GetLuggageQuery, List<GetLuggageQueryResult>>
    {
        private readonly IRepository<CarLuggage> _repository;

        public GetLuggageQueryHandler(IRepository<CarLuggage> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLuggageQueryResult>> Handle(GetLuggageQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLuggageQueryResult
            {
                CarLuggageID = x.CarLuggageID,
                LuggageType = x.LuggageType,
            }).ToList();
        }
    }
}
