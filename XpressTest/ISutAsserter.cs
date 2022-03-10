namespace XpressTest;

public interface ISutAsserter<TSut>
{
    ISutPropertyAsserter<TSut, TProperty> ThenIts<TProperty>(Func<TSut, TProperty> func);
}