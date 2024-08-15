using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CarID);
			values.BrandID = request.BrandID;
			values.BigImageUrl = request.BigImageUrl;
			values.CoverImageUrl = request.CoverImageUrl;
			values.CarFuelID = request.CarFuelID;
			values.Km = request.Km;
			values.CarLuggageID = request.CarLuggageID;
			values.Model = request.Model;
			values.Seat = request.Seat;
			values.CarTransmissionID = request.CarTransmissionID;
			await _repository.UpdateAsync(values);
		}
	}
}
