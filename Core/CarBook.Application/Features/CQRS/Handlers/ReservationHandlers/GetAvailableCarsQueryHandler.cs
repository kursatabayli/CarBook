using MediatR;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Queries.ReservationQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Features.CQRS.Results.ReservationResults;

namespace CarBook.Application.Cars.Queries
{
    public class GetAvailableCarsQueryHandler : IRequestHandler<GetAvailableCarsQuery, List<GetAvailableCarsQueryResult>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetAvailableCarsQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<List<GetAvailableCarsQueryResult>> Handle(GetAvailableCarsQuery request, CancellationToken cancellationToken)
        {
            return await _reservationRepository.GetAvailableCarsAsync(
                request.PickUpDate,
                request.DropOffDate,
                request.PickUpTime,
                request.DropOffTime,
                request.LocationID);
        }
    }
}
