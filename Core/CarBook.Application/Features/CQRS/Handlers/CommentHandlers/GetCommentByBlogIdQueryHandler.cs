using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Features.CQRS.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _repository;

        public GetCommentByBlogIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCommentsByBlogId(request.Id);
            return values.Select(x => new GetCommentByBlogIdQueryResult
            {
                CommentID = x.CommentID,
                BlogID = x.BlogID,
                Name = x.Name,
                CommentText = x.CommentText,
                CreatedDate = x.CreatedDate,
                Email = x.Email,
                IsActive = x.IsActive,
            }).ToList();
        }
    }
}
