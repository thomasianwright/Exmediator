using System;

namespace Exmediator.Exceptions
{
    public class ExmediatorException : Exception
    {
        public ExmediatorException(string message) : base(message)
        {
        }
        
        public ExmediatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        public ExmediatorException()
        {
        }
    }
}