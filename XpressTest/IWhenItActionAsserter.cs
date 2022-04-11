namespace XpressTest;

public interface IWhenItActionAsserter<TSut>
{
    IVoidAsserter<TSut> WhenIt(
        Action<TSut> action
    );
}