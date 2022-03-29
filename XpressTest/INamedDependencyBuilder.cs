namespace XpressTest;

public interface INamedDependencyBuilder<TSut>
{
    IVoidAsserter<TSut> WhenIt(System.Action<TSut> action);

    INamedDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
    )
        where TNewDependency : class;

    IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class;
}