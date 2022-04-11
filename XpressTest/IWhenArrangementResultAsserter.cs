namespace XpressTest;

public interface IWhenArrangementResultAsserter<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IReadArrangement, Func<TSut, TResult>> func
        );
}