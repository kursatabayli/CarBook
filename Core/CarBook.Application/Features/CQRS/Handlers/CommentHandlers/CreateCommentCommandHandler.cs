using CarBook.Application.Features.CQRS.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public CreateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellation)
        {
            await _repository.CreateAsync(new Comment
            {
                Name = request.Name,
                CommentText = request.CommentText,
                CreatedDate = DateTime.UtcNow.ToLocalTime(),
                BlogID = request.BlogID,
                Email = request.Email,
                IsActive = request.IsActive,
            });
        }
    }
}
