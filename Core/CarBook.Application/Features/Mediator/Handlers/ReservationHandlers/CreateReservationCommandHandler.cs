using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
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
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellation)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name = request.Name,
                SurName = request.SurName,
                Email = request.Email,
                Phone = request.Phone,
                BirthDate = request.BirthDate,
                CarID = request.CarID,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                PickUpLocationID = request.PickUpLocationID,
                DropOffLocationID = request.DropOffLocationID,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
