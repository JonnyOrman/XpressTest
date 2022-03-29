namespace XpressTest;

public interface ISutAsserterCreator<TSut>
{
    ISutAsserter<TSut> Create();
}