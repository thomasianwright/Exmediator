﻿using System;
using Exmediator.Enums;

namespace Exmediator.Services
{
    internal interface IExmediatorServiceRegister
    {
        ExmediatorServiceLifetime DefaultLifetime { get; }
        
        void Register(Type implementationType, ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient);
        void Register(Type serviceType, Type implementationType, ExmediatorServiceLifetime lifetime = ExmediatorServiceLifetime.Transient);
    }
}