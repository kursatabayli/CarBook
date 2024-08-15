using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
				BigImageUrl = x.BigImageUrl,
				CoverImageUrl = x.CoverImageUrl,
                CarFuelID = x.CarFuelID,
				Km = x.Km,
                CarLuggageID = x.CarLuggageID,
                Model = x.Model,
				Seat = x.Seat,
                CarTransmissionID = x.CarTransmissionID,

			}).ToList();
		}
	}

}
