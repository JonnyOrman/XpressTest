namespace XpressTest;

public interface ISutFunctionActor<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<ISutArrangement<TSut>, TResult> func
    );
}