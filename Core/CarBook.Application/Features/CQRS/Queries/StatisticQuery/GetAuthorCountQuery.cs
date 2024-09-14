using CarBook.Application.Features.CQRS.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.StatisticQuery
{
    public class GetAuthorCountQuery:IRequest<GetAuthorCountQueryResult>
    {
    }
}
