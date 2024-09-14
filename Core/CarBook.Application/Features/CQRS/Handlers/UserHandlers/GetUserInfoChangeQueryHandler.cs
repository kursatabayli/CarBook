using CarBook.Application.Features.CQRS.Queries.UserQueries;
using CarBook.Application.Features.CQRS.Results.UserResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.UserHandlers
{
    public class GetUserInfoChangeQueryHandler : IRequestHandler<GetUserInfoChangeQuery, GetUserInfoChangeQueryResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserInfoChangeQueryHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserInfoChangeQueryResult> Handle(GetUserInfoChangeQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetUserInfoChangeQueryResult
            {
                OldPassword = x.Password
            }).FirstOrDefault();
        }
    }
}
