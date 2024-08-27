using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.RentACarResults
{
    public class GetAllRentACarQueryResult
    {
        public int LocationID { get; set; }
        public List<int> CarID { get; set; }
    }
}
