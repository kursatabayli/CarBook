using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ReservationCommands
{
    public class CreateReservationCommand : IRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public int CarID { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DriverLicenseYear { get; set; }
        public DateTime PickUpDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public DateTime DropOffDate { get; set; }
        public TimeSpan DropOffTime { get; set; }
        public string? Description { get; set; }
    }
}
