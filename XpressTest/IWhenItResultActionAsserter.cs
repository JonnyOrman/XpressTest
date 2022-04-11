namespace XpressTest;

public interface IWhenItResultActionAsserter<TSut>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<ISutArrangement<TSut>, TResult> func);
}