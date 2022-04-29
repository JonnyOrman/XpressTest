namespace XpressTest;

public interface ISutAsserterCreator<TSut>
{
    ISutPropertyTargeter<TSut> Create();
}