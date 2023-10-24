using System;

namespace Exmediator.Exceptions
{
    public class ExmediatorHandlerNotRegisteredException : ExmediatorException
    {
        public ExmediatorHandlerNotRegisteredException(string message) : base(message)
        {
        }
        
        public ExmediatorHandlerNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public ExmediatorHandlerNotRegisteredException()
        {
        }
        
        public ExmediatorHandlerNotRegisteredException(Type eventType) : base($"Handler for event {eventType.Name} is not registered")
        {
        }
    }
}