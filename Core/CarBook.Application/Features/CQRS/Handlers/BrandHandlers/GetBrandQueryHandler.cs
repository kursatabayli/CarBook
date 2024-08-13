using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetBrandQueryHandler
	{
		private readonly IRepository<Brand> _repository;
		public GetBrandQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}
		public async Task<List<GetBrandQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBrandQueryResult
			{
				BrandID = x.BrandID,
				Name = x.Name,

			}).ToList();
		}
	}
}
