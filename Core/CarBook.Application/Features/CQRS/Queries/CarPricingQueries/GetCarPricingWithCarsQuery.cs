using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarsQuery:IRequest<List<GetCarPricingWithCarsQueryResult>>
    {
    }
}
