using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces.PricingInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class UpdateCarPricingByCarIdCommandHandler : IRequestHandler<UpdateCarPricingByCarIdCommand, Unit>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public UpdateCarPricingByCarIdCommandHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<Unit> Handle(UpdateCarPricingByCarIdCommand request, CancellationToken cancellationToken)
        {
            var carPricings = await _carPricingRepository.GetCarPricingByCarAndPricingIdAsync(request.CarID);

            var dailyPrice = carPricings.FirstOrDefault(x => x.PricingID == 1);
            dailyPrice.Amount = request.DailyPrice;
            var weeklyPrice = carPricings.FirstOrDefault(x => x.PricingID == 2);
            weeklyPrice.Amount = request.WeeklyPrice;
            var monthlyPrice = carPricings.FirstOrDefault(x => x.PricingID == 3);
            monthlyPrice.Amount = request.MonthlyPrice;

            await _carPricingRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
