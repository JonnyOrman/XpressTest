namespace XpressTest;

public interface IActor<TSut>
    :
        IWhenItActionAsserter<TSut>,
        IWhenItSutActionAsserter<TSut>,
        IWhenItResultActionAsserter<TSut>,
        IWhenArrangementResultAsserter<TSut>,
        IConstructedSutAsserter<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func);

    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );

    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
    );
}