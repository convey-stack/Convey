using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convey
{
    public static class Extensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(sectionName).Bind(model);
            return model;
        }
        
        public static TModel GetOptions<TModel>(this IConveyBuilder builder, string settingsSectionName) where TModel : new()
        {
            using (var serviceProvider = builder.Services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                return configuration.GetOptions<TModel>(settingsSectionName);
            }
        }
    }
}