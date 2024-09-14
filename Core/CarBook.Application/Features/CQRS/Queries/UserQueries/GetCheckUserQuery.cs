using CarBook.Application.Features.CQRS.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.UserQueries
{
    public class GetCheckUserQuery : IRequest<GetCheckUserQueryResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
