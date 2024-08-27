using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.RentACarDtos
{
    public class ResultRentACarDto
    {
        public int LocationID { get; set; }
        public List<int> CarID { get; set; }
    }
}
