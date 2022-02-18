namespace XpressTest;

public interface IAssertion<TSut, TResult> : IArrangement
{
    TResult Result { get; }
    
    IAction<TSut> Action { get; }
}