using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarQueryHandlers
{
    public class GetAllRentACarQueryHandler : IRequestHandler<GetAllRentACarQuery, List<GetAllRentACarQueryResult>>
    {
        private readonly IRepository<RentACar> _repository;

        public GetAllRentACarQueryHandler(IRepository<RentACar> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllRentACarQueryResult>> Handle(GetAllRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.GroupBy(g=>g.LocationID)
                .Select(x => new GetAllRentACarQueryResult
            {
                LocationID = x.Key,
                CarID = x.Select(y => y.CarID).ToList()

                }).OrderByDescending(x=>x.CarID.Count).ToList();
        }
    }
}
