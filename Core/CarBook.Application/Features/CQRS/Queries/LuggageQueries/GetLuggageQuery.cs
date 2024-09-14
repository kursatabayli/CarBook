using CarBook.Application.Features.CQRS.Results.LuggageResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.LuggageQueries
{
    public class GetLuggageQuery:IRequest<List<GetLuggageQueryResult>>
    {
    }
}
