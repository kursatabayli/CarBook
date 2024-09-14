using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
	public class GetAboutQueryHandler:IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
	{
		private readonly IRepository<About> _repository;

		public GetAboutQueryHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutID = x.AboutID,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
