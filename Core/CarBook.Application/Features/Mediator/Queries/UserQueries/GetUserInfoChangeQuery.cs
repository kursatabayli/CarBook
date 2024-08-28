using CarBook.Application.Features.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.UserQueries
{
    public class GetUserInfoChangeQuery:IRequest<GetUserInfoChangeQueryResult>
    {
    }
}
