using CarBook.Application.Features.CQRS.Queries.StatisticQuery;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.StatisticHandler
{
    internal class GetTestimonialsCountQueryHandler : IRequestHandler<GetTestimonialsCountQuery, GetTestimonialsCountQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetTestimonialsCountQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialsCountQueryResult> Handle(GetTestimonialsCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetTestimonialCount();
            return new GetTestimonialsCountQueryResult
            {
                TestimonialsCount = value,
            };
        }

        
    }
}
