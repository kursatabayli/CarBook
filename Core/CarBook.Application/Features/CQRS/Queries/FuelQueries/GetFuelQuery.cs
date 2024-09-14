using CarBook.Application.Features.CQRS.Results.FuelResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.FuelQueries
{
    public class GetFuelQuery:IRequest<List<GetFuelQueryResult>>
    {
    }
}
