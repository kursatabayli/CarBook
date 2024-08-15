using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarDetailsyIdQueryHandler : IRequestHandler<GetCarDetailsByIdQuery, GetCarDetaisByIdQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarDetailsyIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDetaisByIdQueryResult> Handle(GetCarDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDetailsById(request.Id);
            return new GetCarDetaisByIdQueryResult
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                BrandName = values.Brand.Name,
                BigImageUrl = values.BigImageUrl,
                CoverImageUrl = values.CoverImageUrl,
                CarFuelID = values.CarFuelID,
                FuelType = values.CarFuel.FuelType,
                Km = values.Km,
                CarLuggageID = values.CarLuggageID,
                LuggageType = values.CarLuggage.LuggageType,
                Model = values.Model,
                Seat = values.Seat,
                CarTransmissionID = values.CarTransmissionID,
                TransmissionType = values.CarTransmission.TransmissionType,
            };
        }

    }
}
