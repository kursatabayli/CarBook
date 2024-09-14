using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using CarBook.Application.Features.CQRS.Results.CommentResults;
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
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCommentQueryResult
            {
                CommentID = x.CommentID,
                Name = x.Name,
                CommentText = x.CommentText,
                CreatedDate = x.CreatedDate,
                BlogID = x.BlogID,
                Email = x.Email,
                IsActive = x.IsActive,
            }).ToList();
        }
    }
}
