using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
	public class UpdateBannerCommandHandler:IRequestHandler<UpdateBannerCommand>
	{
		private readonly IRepository<Banner> _repository;

		public UpdateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BannerID);
            values.Title = request.Title;
            values.Description = request.Description;
            values.VideoDescription = request.VideoDescription;
            values.VideoUrl = request.VideoUrl;
            values.BannerImageUrl = request.BannerImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
