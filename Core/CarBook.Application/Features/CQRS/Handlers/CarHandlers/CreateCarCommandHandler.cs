using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellation)
        {
            await _repository.CreateAsync(new Car
            {
                BrandID = request.BrandID,
				BigImageUrl = request.BigImageUrl,
				CoverImageUrl = request.CoverImageUrl,
				CarFuelID = request.CarFuelID,
				Km = request.Km,
                CarLuggageID = request.CarLuggageID,
                Model = request.Model,
				Seat = request.Seat,
                CarTransmissionID = request.CarTransmissionID,
			});
		}
	}
}
