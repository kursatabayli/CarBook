using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarLuggage
    {
        public int CarLuggageID { get; set; }
        public string LuggageType { get; set; }
        public List<Car> Cars { get; set; }
    }
}
