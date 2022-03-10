namespace XpressTest;

public interface ISutPropertyTargeter<TSut>
{
    ISutPropertyAsserter<TSut, TProperty> ThenIts<TProperty>(Func<TSut, TProperty> func);
}