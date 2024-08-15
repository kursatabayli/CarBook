using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarFuel
    {
        public int CarFuelID { get; set; }
        public string FuelType { get; set; }
        public List<Car> Cars { get; set; }
    }
}
