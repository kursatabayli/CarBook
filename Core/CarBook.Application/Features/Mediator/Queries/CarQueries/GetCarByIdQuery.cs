using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
    public class GetCarByIdQuery:IRequest<GetCarByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarByIdQuery(int id)
        {
            Id = id;
        }
    }
}
