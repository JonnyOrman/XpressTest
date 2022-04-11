namespace XpressTest;

public interface IConstructedSutAsserter<TSut>
{
    ISutPropertyTargeter<TSut> WhenItIsConstructed();
}