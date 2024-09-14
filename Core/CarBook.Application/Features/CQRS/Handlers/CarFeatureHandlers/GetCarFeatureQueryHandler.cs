using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using CarBook.Application.Features.CQRS.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureQueryHandler : IRequestHandler<GetCarFeatureQuery, List<GetCarFeatureQueryResult>>
    {
        private readonly IRepository<CarFeature> _repository;

        public GetCarFeatureQueryHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureQueryResult>> Handle(GetCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x=> new GetCarFeatureQueryResult
            {
                CarFeatureID = x.CarFeatureID,
                CarID = x.CarID,
                FeatureID = x.FeatureID,
                Available = x.Available,

            }).ToList();
        }
    }
}
