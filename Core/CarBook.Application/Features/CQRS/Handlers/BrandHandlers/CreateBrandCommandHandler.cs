using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommand>
	{
		private readonly IRepository<Brand> _repository;
		public CreateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

        public async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Brand
            {
                Name = request.Name,
            });
        }
    }
}
