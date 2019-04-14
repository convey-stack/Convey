using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Convey
{
    public sealed class ConveyBuilder : IConveyBuilder
    {
        private readonly List<string> _registry;
        private readonly IServiceCollection _services;
        IServiceCollection IConveyBuilder.Services => _services;

        private ConveyBuilder(IServiceCollection services)
            => (_services, _registry) = (services, new List<string>());

        public static IConveyBuilder Create(IServiceCollection services)
            => new ConveyBuilder(services);

        public bool TryRegister(string name)
        {
            var isAlreadyRegistered = _registry.Any(r => r == name);
            
            if (isAlreadyRegistered)
            {
                return false;
            }
            
            _registry.Add(name);
            return true;
        }

        public IServiceProvider Build()
            => _services.BuildServiceProvider();
    }
}