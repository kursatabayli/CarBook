using CarBook.Application.Features.CQRS.Results.ReservationResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        Task<List<GetAvailableCarsQueryResult>> GetAvailableCarsAsync(DateTime pickUpDate, DateTime dropOffDate, TimeSpan pickUpTime, TimeSpan dropOffTime, int locationID);

    }
}
