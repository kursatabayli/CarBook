using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarTransmission
    {
        public int CarTransmissionID { get; set; }
        public string TransmissionType { get; set; }
        public List<Car> Cars { get; set; }
    }
}
