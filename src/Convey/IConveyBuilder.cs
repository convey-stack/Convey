using System;
using Microsoft.Extensions.DependencyInjection;

namespace Convey
{
    public interface IConveyBuilder
    {
        IServiceCollection Services { get; }
        bool TryRegister(string name);
        void AddBuildAction(Action<IServiceProvider> execute);
        IServiceProvider Build();
    }
}