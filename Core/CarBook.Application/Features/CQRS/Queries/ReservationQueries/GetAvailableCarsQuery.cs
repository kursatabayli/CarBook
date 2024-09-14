using CarBook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ReservationQueries
{
    public class GetAvailableCarsQuery:IRequest<List<GetAvailableCarsQueryResult>>
    {
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public TimeSpan DropOffTime { get; set; }
        public int LocationID { get; set; }
    }
}
