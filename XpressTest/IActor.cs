namespace XpressTest;

public interface IActor<TSut>
{
    IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func);

    IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func);
}