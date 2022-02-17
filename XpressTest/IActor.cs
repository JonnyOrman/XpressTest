namespace XpressTest;

public interface IActor<TSut>
{
    IAsserter<Action<TResult>> WhenIt<TResult>(Func<TSut, TResult> func);
    
    IAsserter<Action> WhenIt(Action<TSut> func);
}