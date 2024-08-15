using CarBook.Application.Features.Mediator.Results.LuggageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.LuggageQueries
{
    public class GetLuggageQuery:IRequest<List<GetLuggageQueryResult>>
    {
    }
}
