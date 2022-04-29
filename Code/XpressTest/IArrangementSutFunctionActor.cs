namespace XpressTest;

public interface IArrangementSutFunctionActor<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
        );
}