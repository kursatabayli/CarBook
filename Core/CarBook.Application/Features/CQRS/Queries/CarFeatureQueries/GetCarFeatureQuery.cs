using CarBook.Application.Features.CQRS.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarFeatureQueries
{
    public class GetCarFeatureQuery:IRequest<List<GetCarFeatureQueryResult>>
    {
    }
}
