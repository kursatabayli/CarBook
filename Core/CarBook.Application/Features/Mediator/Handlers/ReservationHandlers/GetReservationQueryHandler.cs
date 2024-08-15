using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationQueryResult
            {
                ReservationID = x.ReservationID,
                Name = x.Name,
                SurName = x.SurName,
                BirthDate = x.BirthDate,
                Phone = x.Phone,
                Email = x.Email,
                DriverLicenseYear = x.DriverLicenseYear,
                CarID = x.CarID,
                PickUpLocationID = x.PickUpLocationID,
                DropOffLocationID = x.DropOffLocationID
            }).ToList();
        }
    }
}
