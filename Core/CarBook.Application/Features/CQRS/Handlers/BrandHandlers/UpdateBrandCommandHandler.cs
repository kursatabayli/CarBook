using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommand>
	{
		private readonly IRepository<Brand> _repository;

		public UpdateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

        public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BrandID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}



