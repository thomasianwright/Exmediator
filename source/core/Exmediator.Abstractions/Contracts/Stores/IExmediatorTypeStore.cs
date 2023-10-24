using System;
using System.Collections.Generic;
using Exmediator.Models;

namespace Exmediator.Stores
{
    public interface IExmediatorTypeStore
    {
        void Add(Type eventType, Type handlerType);
        void AddRange(IEnumerable<KeyValuePair<Type, Type>> pairs);
        HandlerMetadata TryGet(Type eventType);
        HandlerMetadata Get(Type eventType);
        bool Contains(Type eventType);
        void SetInitialized();
    }
}