using CarBook.Application.Features.CQRS.Commands.UserCommands;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.UserID);
            values.UserName = request.UserName;
            values.Email = request.Email;
            values.Password = request.Password;
            await _repository.UpdateAsync(values);
        }
    }
}
