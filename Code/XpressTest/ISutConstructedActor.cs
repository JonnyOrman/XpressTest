namespace XpressTest;

public interface ISutConstructedActor<TSut>
{
    ISutPropertyTargeter<TSut> WhenItIsConstructed();
}