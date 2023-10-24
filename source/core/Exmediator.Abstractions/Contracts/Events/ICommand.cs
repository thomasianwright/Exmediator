namespace Exmediator.Events
{
    public interface ICommand<TResponse> : ICallbackEvent
    {
        
    }
    
    public interface ICommand : ICommand<Unit> { }
}