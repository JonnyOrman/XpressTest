namespace XpressTest;

public interface ISutArrangementActionActor<TSut>
{
    IVoidAsserter<TSut> WhenIt(
        Action<ISutArrangement<TSut>> action
    );
}