using CarBook.Application.Features.CQRS.Results.FooterAddressResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.FooterAddressQueries
{
	public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
	{
	}
}
