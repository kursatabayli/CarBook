using CarBook.Application.Features.CQRS.Queries.UserQueries;
using CarBook.Application.Features.CQRS.Results.UserResults;
using CarBook.Application.Interfaces.UserInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.UserHandlers
{
    public class GetCheckUserQueryHandler : IRequestHandler<GetCheckUserQuery, GetCheckUserQueryResult>
    {
        private readonly IUserRepository _UserRepository;

        public GetCheckUserQueryHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<GetCheckUserQueryResult> Handle(GetCheckUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckUserQueryResult();
            var user = await _UserRepository.GetByFilterAsync(x => x.Email == request.Email && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.Email = request.Email;
                values.Password = request.Password;
            }

            return values;
        }
    }
}
