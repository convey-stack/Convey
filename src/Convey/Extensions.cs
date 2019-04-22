using System;
using System.Threading.Tasks;
using Convey.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convey
{
    public static class Extensions
    {
        public static IConveyBuilder AddConvey(this IServiceCollection services)
            => ConveyBuilder.Create(services);

        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
            where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(sectionName).Bind(model);
            return model;
        }

        public static TModel GetOptions<TModel>(this IConveyBuilder builder, string settingsSectionName)
            where TModel : new()
        {
            using (var serviceProvider = builder.Services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                return configuration.GetOptions<TModel>(settingsSectionName);
            }
        }

        public static Task InitAsync(this IApplicationBuilder app)
        {
            var initializer = app.ApplicationServices.GetService<IStartupInitializer>();
            if (initializer is null)
            {
                throw new InvalidOperationException("Startup initializer was not found.");
            }

            return initializer.InitializeAsync();
        }
    }
}