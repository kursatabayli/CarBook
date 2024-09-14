using CarBook.Application.Features.CQRS.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellation)
        {
            await _repository.CreateAsync(new Blog
            {
                Title = request.Title,
                AuthorID = request.AuthorID,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = request.CreatedDate,
                CategoryID = request.CategoryID,
                Description = request.Description,
                
            });
        }

    }
}
