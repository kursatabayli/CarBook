using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class GetBrandQueryHandler:IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
	{
		private readonly IRepository<Brand> _repository;
		public GetBrandQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
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
