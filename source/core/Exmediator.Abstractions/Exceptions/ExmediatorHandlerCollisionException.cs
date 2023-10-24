using System;

namespace Exmediator.Exceptions
{
    public class ExmediatorHandlerCollisionException : ExmediatorException
    {
        public ExmediatorHandlerCollisionException(Type eventType, Type handlerType) : base($"Handler {handlerType.Name} is already registered for event {eventType.Name}")
        {
            
        }
        
        public ExmediatorHandlerCollisionException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public ExmediatorHandlerCollisionException()
        {
        }
    }
}