using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        [Key]
        public int CarID { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        public string Model { get; set; }

        public string CoverImageUrl { get; set; }
        public int Km { get; set; }

        public int CarTransmissionID { get; set; }
        public CarTransmission CarTransmission { get; set; }

        public byte Seat { get; set; }

        public int CarLuggageID { get; set; }
        public CarLuggage CarLuggage { get; set; }

        public int CarFuelID { get; set; }
        public CarFuel CarFuel { get; set; }

        public string BigImageUrl { get; set; }

        public List<CarFeature> CarFeatures { get; set; }
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
        public List<RentACar> RentACars { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
