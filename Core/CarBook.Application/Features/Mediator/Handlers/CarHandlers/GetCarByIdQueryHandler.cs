using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
				BrandID = values.BrandID,
				BigImageUrl = values.BigImageUrl,
				CoverImageUrl = values.CoverImageUrl,
                CarFuelID = values.CarFuelID,
				Km = values.Km,
                CarLuggageID = values.CarLuggageID,
                Model = values.Model,
				Seat = values.Seat,
                CarTransmissionID = values.CarTransmissionID

            };
		}
	}
}
