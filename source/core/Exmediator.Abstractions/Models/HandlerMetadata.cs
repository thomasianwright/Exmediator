using System;
using System.Reflection;
using Exmediator.Events;
using Exmediator.Handlers;

namespace Exmediator.Models
{
    public class HandlerMetadata
    {
        public string HandlerName { get; set; }
        public string HandlerFullName { get; set; }

        public Type HandlerType { get; set; }
        public Type EventType { get; set; }
        public Type ResponseType { get; set; }

        public HandlerMetadata(string handlerName, string handlerFullName, Type handlerType, Type eventType)
        {
            HandlerName = handlerName;
            HandlerFullName = handlerFullName;
            HandlerType = handlerType;
            EventType = eventType;
        }

        internal MethodInfo HandleAsyncMethod { get; set; }
        internal MethodInfo HandleErrorAsyncMethod { get; set; }

        private void Initialize()
        {
            HandleAsyncMethod = HandlerType.GetMethod("HandleAsync", BindingFlags.Public | BindingFlags.Instance);
            HandleErrorAsyncMethod =
                HandlerType.GetMethod("HandleErrorAsync", BindingFlags.Public | BindingFlags.Instance);

            var typeHandlerInterfaces = HandlerType.GetInterfaces();

            var callbackHandlerInterface = typeof(ICallbackHandler<,>).MakeGenericType(EventType, ResponseType);

            if (HandlerType.IsGenericType && HandlerType.GetGenericTypeDefinition() == callbackHandlerInterface)
            {
                ResponseType = HandlerType.GetGenericArguments()[1];
            }
        }
    }
}