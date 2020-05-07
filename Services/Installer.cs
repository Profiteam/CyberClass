using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services
{
    public static class Installer
    {
        public static void AddBuisnessServices(this IServiceCollection container)
        {
            container
                .AddScoped<IUserService, UserService>()
                .AddScoped<IRatingService, RatingService>()
                .AddScoped<IMaterialService, MaterialService>()
                .AddScoped<ILessonService, LessonService>()
                .AddScoped<IOrderService, OrderService>();
        }
    }
}
