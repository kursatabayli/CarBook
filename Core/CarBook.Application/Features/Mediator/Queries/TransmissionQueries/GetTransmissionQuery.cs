using CarBook.Application.Features.Mediator.Results.TransmissionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TransmissionQueries
{
    public class GetTransmissionQuery:IRequest<List<GetTransmissionQueryResult>>
    {
    }
}
