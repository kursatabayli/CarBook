using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler:IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
	{
		private readonly IRepository<Contact> _repository;

		public GetContactQueryHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Subject = x.Subject,
                SendDate = x.SendDate,
            }).ToList();
        }
    }
}
