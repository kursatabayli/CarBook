using CarBook.Application.Features.Mediator.Results.FuelResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FuelQueries
{
    public class GetFuelQuery:IRequest<List<GetFuelQueryResult>>
    {
    }
}
