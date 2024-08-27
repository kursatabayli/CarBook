using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BannerCommands
{
	public class UpdateBannerCommand : IRequest
    {
		public int BannerID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string VideoDescription { get; set; }
		public string VideoUrl { get; set; }
        public string BannerImageUrl { get; set; }

    }
}
