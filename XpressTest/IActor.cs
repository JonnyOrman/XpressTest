namespace XpressTest;

public interface IActor<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
        );

    IVoidAsserter<TSut> WhenIt(
        System.Action<TSut> action
        );
    
    IVoidAsserter<TSut> WhenIt(
        System.Action<IAction<TSut>> func
        );
}