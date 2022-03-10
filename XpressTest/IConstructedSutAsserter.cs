namespace XpressTest;

public interface IConstructedSutAsserter<TSut>
{
    ISutAsserter<TSut> WhenItIsConstructed();
}