using CarBook.Application.Features.CQRS.Results.TransmissionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.TransmissionQueries
{
    public class GetTransmissionQuery:IRequest<List<GetTransmissionQueryResult>>
    {
    }
}
