using CarBook.Application.Features.Mediator.Queries.TransmissionQueries;
using CarBook.Application.Features.Mediator.Results.TransmissionResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TransmissionHandlers
{
    public class GetTransmissionQueryHandler : IRequestHandler<GetTransmissionQuery, List<GetTransmissionQueryResult>>
    {
        private readonly IRepository<CarTransmission> _repository;

        public GetTransmissionQueryHandler(IRepository<CarTransmission> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTransmissionQueryResult>> Handle(GetTransmissionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTransmissionQueryResult
            {
                CarTransmissionID = x.CarTransmissionID,
                TransmissionType = x.TransmissionType,
            }).ToList();
        }
    }
}
