using CarBook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ReservationQueries
{
    public class GetReservationByIdQuery:IRequest<GetReservationByIdQueryResult>
    {
        public int Id { get; set; }

        public GetReservationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
