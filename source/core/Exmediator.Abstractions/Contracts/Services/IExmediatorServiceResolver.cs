using System;
using Exmediator.Events;
using Exmediator.Handlers;

namespace Exmediator.Services
{
    public interface IExmediatorServiceResolver
    {
        TService GetService<TService>();
        
        object GetService(Type serviceType);
    }
}