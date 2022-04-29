namespace XpressTest;

public interface IActor<TSut>
    :
        IActionActor<TSut>,
        ISutArrangementActionActor<TSut>,
        ISutFunctionActor<TSut>,
        IArrangementSutFunctionActor<TSut>,
        ISutConstructedActor<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<TSut, TResult> func);

    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<ISutArrangement<TSut>, Task<TResult>> func
    );

    IAsyncResultAsserter<TSut, TResult> WhenItAsync<TResult>(
        Func<TSut, Task<TResult>> func
    );
}