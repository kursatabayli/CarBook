using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryQueryHandler:IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryID = x.CategoryID,
                Name = x.Name,
            }).ToList();
        }
    }
}
