using System;
using Microsoft.Extensions.DependencyInjection;

namespace Convey
{
    public sealed class ConveyBuilder : IConveyBuilder
    {
        private readonly IServiceCollection _services;
        IServiceCollection IConveyBuilder.Services => _services;

        private ConveyBuilder(IServiceCollection services)
            => _services = services;

        public static IConveyBuilder Create(IServiceCollection services)
            => new ConveyBuilder(services);
        
        public IServiceProvider Build()
            => _services.BuildServiceProvider();
    }
}