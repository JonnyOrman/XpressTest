namespace XpressTest;

public interface IResultAsserterComposer<TSut>
{
    IResultAsserter<TSut, TResult> Compose<TResult>(
        Func<IAction<TSut>, TResult> func, 
        IArrangement arrangement
        );
}