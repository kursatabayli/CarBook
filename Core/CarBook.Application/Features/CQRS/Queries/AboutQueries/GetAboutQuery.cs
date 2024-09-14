using CarBook.Application.Features.CQRS.Results.AboutResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutQuery:IRequest<List<GetAboutQueryResult>>
    {
    }
}
