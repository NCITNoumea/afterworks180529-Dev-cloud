using Microsoft.Extensions.DependencyInjection;
using MS.Afterworks.HappyFace.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Afterworks.HappyFace.Services
{
    public static class IServiceCollectionExtensions
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
