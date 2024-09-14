using CarBook.Application.Features.CQRS.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
	public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
	{
		private readonly IRepository<SocialMedia> _repository;

		public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellation)
		{
			await _repository.CreateAsync(new SocialMedia
			{
				Name = request.Name,
				Icon = request.Icon,
				Url = request.Url,
			});
		}
	}
}
