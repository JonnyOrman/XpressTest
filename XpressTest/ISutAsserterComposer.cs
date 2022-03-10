namespace XpressTest;

public interface ISutAsserterComposer<TSut>
{
    ISutAsserter<TSut> Compose<TDependency>(
        TDependency dependency,
        IArrangement arrangement
    );
}