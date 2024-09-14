using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarDetailsByIdQueryHandler : IRequestHandler<GetCarDetailsByIdQuery, GetCarDetaisByIdQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarDetailsByIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDetaisByIdQueryResult> Handle(GetCarDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDetailsById(request.Id);
			return new GetCarDetaisByIdQueryResult
			{
				CarID = values.CarID,
				BrandName = values.Brand.Name,
				BigImageUrl = values.BigImageUrl,
				CoverImageUrl = values.CoverImageUrl,
				FuelType = values.CarFuel.FuelType,
				Km = values.Km,
				LuggageType = values.CarLuggage.LuggageType,
				Model = values.Model,
				Seat = values.Seat,
				TransmissionType = values.CarTransmission.TransmissionType,
				FeatureName = values.CarFeatures.Select(xd => xd.Feature.Name).ToList(),
				Available = values.CarFeatures.Select(xd => xd.Available).ToList(),
				Details = values.CarDescriptions.Select(xd=>xd.Details).First(),
			};
		}

    }
}
