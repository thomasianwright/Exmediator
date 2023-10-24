using System;
using Exmediator.Enums;

namespace Exmediator.Services
{
    public interface IExmediatorServiceRegister
    {
        ExmediatorServiceLifetime DefaultLifetime { get; }
        
        void Register(Type implementationType, ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient);
        void Register(Type serviceType, Type implementationType, ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient);
        
        void Register(Type serviceType, object implementationInstance, ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient);
    }
}