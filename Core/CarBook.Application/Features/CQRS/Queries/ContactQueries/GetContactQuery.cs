using CarBook.Application.Features.CQRS.Results.ContactResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactQuery : IRequest<List<GetContactQueryResult>>
    {
    }
}
