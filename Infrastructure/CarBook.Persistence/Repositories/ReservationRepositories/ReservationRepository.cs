using CarBook.Application.Features.Mediator.Results.ReservationResults;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarBookContext _context;

        public ReservationRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<GetAvailableCarsQueryResult>> GetAvailableCarsAsync(
            DateTime pickUpDate, DateTime dropOffDate, TimeSpan pickUpTime, TimeSpan dropOffTime, int locationID)
        {
            var availableCars = await _context.Cars
                .Where(car => _context.RentACars
                    .Any(rentCar =>
                        rentCar.CarID == car.CarID &&
                        rentCar.LocationID == locationID &&
                        rentCar.Available &&
                        !_context.Reservations
                            .Any(reservation =>
                                reservation.CarID == car.CarID &&
                                reservation.PickUpLocationID == locationID &&
                                !(
                                    (pickUpDate > reservation.DropOffDate) ||
                                    (dropOffDate < reservation.PickUpDate) ||
                                    (pickUpDate == reservation.DropOffDate && pickUpTime >= reservation.DropOffTime) ||
                                    (dropOffDate == reservation.PickUpDate && dropOffTime <= reservation.PickUpTime)
                                )
                            )
                    )
                )
                .Select(car => new GetAvailableCarsQueryResult
                {
                    CarID = car.CarID,
                    BrandName = car.Brand.Name,
                    Model = car.Model,
                    DailyPrice = car.CarPricings
                        .Where(x => x.PricingID == 1)
                        .Select(x => x.Amount)
                        .FirstOrDefault(),
                    CoverImageUrl = car.CoverImageUrl,
                    PricingName = car.CarPricings
                        .Select(x => x.Pricing.Name)
                        .FirstOrDefault(),
                    Amount = car.CarPricings
                        .Select(x => x.Amount)
                        .FirstOrDefault(),
                })
                .ToListAsync();

            return availableCars;
        }

    }
}
