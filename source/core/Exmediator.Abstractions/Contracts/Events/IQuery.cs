namespace Exmediator.Events
{
    public interface IQuery<TResponse> : ICallbackEvent
    {
    }
    
    public interface IQuery : IQuery<Unit> { }
}