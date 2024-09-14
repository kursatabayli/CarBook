using CarBook.Application.Features.CQRS.Results.FooterAddressResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.FooterAddressQueries
{
	public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
	{
		public int Id { get; set; }

		public GetFooterAddressByIdQuery(int id)
		{
			Id = id;
		}
	}
}
