using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class GetBlogAuthorByIdQueryHandler : IRequestHandler<GetBlogAuthorByIdQuery, List<GetBlogAuthorByIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogAuthorByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogAuthorByIdQueryResult>> Handle(GetBlogAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAuthorByBlogId(request.Id);
            return values.Select(x => new GetBlogAuthorByIdQueryResult
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                AuthorName = x.Author.Name,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorDescription = x.Author.Description,
            }).ToList();
        }
    }
}
