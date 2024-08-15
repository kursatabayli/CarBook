using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public sbyte CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }
    }
}
