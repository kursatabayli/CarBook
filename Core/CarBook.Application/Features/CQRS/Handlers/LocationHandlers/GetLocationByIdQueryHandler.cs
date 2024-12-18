﻿using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
	public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
	{
		private readonly IRepository<Location> _repository;

		public GetLocationByIdQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetLocationByIdQueryResult
			{
				LocationID = values.LocationID,
				Name = values.Name,
				Maps = values.Maps,
			};
		}
	}
}
