using CarBook.Application.Features.CQRS.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CommentQueries
{
    public class GetCommentByBlogIdQuery : IRequest<List<GetCommentByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
