namespace XpressTest;

public interface IWhenItSutActionAsserter<TSut>
{
    IVoidAsserter<TSut> WhenIt(
        Action<ISutArrangement<TSut>> func
    );
}