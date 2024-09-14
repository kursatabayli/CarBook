using CarBook.Application.Features.CQRS.Queries.ReservationQueries;
using CarBook.Application.Features.CQRS.Results.ReservationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetReservationByIdQueryResult
            {
                ReservationID = values.ReservationID,
                Name = values.Name,
                SurName = values.SurName,
                BirthDate = values.BirthDate,
                Phone = values.Phone,
                Email = values.Email,
                DriverLicenseYear = values.DriverLicenseYear,
                Description = values.Description,
                PickUpLocationID = values.PickUpLocationID,
                DropOffLocationID = values.DropOffLocationID,
                CarID = values.CarID,
                PickUpDate = values.PickUpDate,
                DropOffDate = values.DropOffDate,
                PickUpTime = values.PickUpTime,
                DropOffTime = values.DropOffTime,

            };
        }
    }
}
