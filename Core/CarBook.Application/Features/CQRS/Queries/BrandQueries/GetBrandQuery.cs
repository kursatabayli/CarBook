using CarBook.Application.Features.CQRS.Results.BrandResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandQuery : IRequest<List<GetBrandQueryResult>>
    {
    }
}
