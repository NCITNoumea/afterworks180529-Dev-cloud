using Microsoft.Extensions.DependencyInjection;
using MS.Afterworks.HappyFace.Infrastructure.Repositories;

namespace MS.Afterworks.HappyFace.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISmileRepository, SmileRepository>();
        }

        public static void AddCognitiveServices(this IServiceCollection services)
        {
            services.AddScoped<ITextAnalyticsService, TextAnalyticsService>();
        }
    }
}
