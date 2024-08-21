using CarBook.Application.Features.Mediator.Queries.CategoryQueries;
using CarBook.Application.Features.Mediator.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CategoryHandlers
{
	public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
	{
		private readonly IRepository<Category> _repository;

		public GetCategoryByIdQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = values.CategoryID,
                Name = values.Name
            };
        }
    }
}
