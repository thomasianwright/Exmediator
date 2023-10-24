using System;
using System.Collections.Generic;
using System.Linq;
using Exmediator.Exceptions;
using Exmediator.Models;

namespace Exmediator.Stores
{
    public class ExmediatorTypeStore : IExmediatorTypeStore
    {
        /// <summary>
        /// Event -- Handler
        /// </summary>
        readonly IDictionary<int, HandlerMetadata> _store = new Dictionary<int, HandlerMetadata>();
        
        private bool IsInitialized { get; set; }
        
        public void Add(Type eventType, Type handlerType)
        {
            if (IsInitialized)
                throw new ExmediatorException("ExmediatorTypeStore is initialized");

            var handlerMetadata = new HandlerMetadata(handlerType.Name, handlerType.FullName, handlerType, eventType);
            
            if (_store.ContainsKey(eventType.GetHashCode()))
                throw new ExmediatorException($"Handler for event {eventType.Name} already exists");

            _store.Add(eventType.GetHashCode(), handlerMetadata);
        }
        
        public void AddRange(IEnumerable<KeyValuePair<Type, Type>> pairs)
        {
            foreach (var pair in pairs)
            {
                Add(pair.Key, pair.Value);
            }
        }
        
        public HandlerMetadata TryGet(Type eventType)
        {
            if (_store.TryGetValue(eventType.GetHashCode(), out var handlerMetadata))
                return handlerMetadata;

            return null;
        }
        
        public HandlerMetadata Get(Type eventType)
        {
            if (_store.TryGetValue(eventType.GetHashCode(), out var handlerMetadata))
                return handlerMetadata;

            throw new ExmediatorException($"Handler for event {eventType.Name} not found");
        }
        
        public bool Contains(Type eventType)
        {
            return _store.ContainsKey(eventType.GetHashCode());
        }
        
        public IList<Type> GetRegisteredTypes()
        {
            return _store.Select(handlerMetadata => handlerMetadata.Value.HandlerType).ToList();
        }
        
        public void SetInitialized()
        {
            if (IsInitialized)
                throw new ExmediatorException("ExmediatorTypeStore is initialized");
            
            IsInitialized = true;
        }
    }
}