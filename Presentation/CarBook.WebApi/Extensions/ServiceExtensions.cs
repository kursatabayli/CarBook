using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarFeaturesInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Application.Interfaces.PricingInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Application.Interfaces.UserInterfaces;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories.BlogRepostories;
using CarBook.Persistence.Repositories.CarFeatureRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarReporsitories;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Persistence.Repositories.RentACarRepositories;
using CarBook.Persistence.Repositories.ReservationRepositories;
using CarBook.Persistence.Repositories.ReviewRepositories;
using CarBook.Persistence.Repositories.StatisticRepositories;
using CarBook.Persistence.Repositories.TagCloudRepositories;
using CarBook.Persistence.Repositories.UserRepositories;
using CarBook.Persistence.Repositories;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<CarBookContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
        services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
        services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
        services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
        services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
        services.AddScoped(typeof(IStatisticRepository), typeof(StatisticRepository));
        services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
        services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
        services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));

        return services;
    }
}
