using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.ReservationDtos
{
    public class ResultReservationDto
    {
        public int ReservationID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PickUpLocationID { get; set; }
        public int DropOffLocationID { get; set; }
        public int CarID { get; set; }
        public string PickUpLocationName { get; set; }
        public string DropOffLocationName { get; set; }
        public string BrandAndModel { get; set; }
        public Decimal Amount { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DriverLicenseYear { get; set; }
        public DateTime PickUpDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public DateTime DropOffDate { get; set; }
        public TimeSpan DropOffTime { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
