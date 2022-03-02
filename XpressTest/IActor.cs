namespace XpressTest;

public interface IActor<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func);

    IVoidAsserter<TSut, System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func);
}