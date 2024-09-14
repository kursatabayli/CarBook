using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
	public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
	{
		private readonly IRepository<Location> _repository;

		public GetLocationQueryHandler(IRepository<Location> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetLocationQueryResult
			{
				LocationID = x.LocationID,
				Name = x.Name,
				Maps = x.Maps,
			}).ToList();
		}
	}
}
