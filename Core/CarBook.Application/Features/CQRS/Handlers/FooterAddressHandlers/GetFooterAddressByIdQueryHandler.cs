﻿using CarBook.Application.Features.CQRS.Queries.FooterAddressQueries;
using CarBook.Application.Features.CQRS.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
	public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
	{
		private readonly IRepository<FooterAddress> _repository;

		public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
		{
			_repository = repository;
		}

		public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetFooterAddressByIdQueryResult
			{
				FooterAddressID = values.FooterAddressID,
				Address = values.Address,
				Description = values.Description,
				Email = values.Email,
				Phone = values.Phone

			};
		}
	}
}
