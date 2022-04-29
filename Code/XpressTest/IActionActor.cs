namespace XpressTest;

public interface IActionActor<TSut>
{
    IVoidAsserter<TSut> WhenIt(
        Action<TSut> action
    );
}