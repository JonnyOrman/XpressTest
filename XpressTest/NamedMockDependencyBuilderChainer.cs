namespace XpressTest;

public class NamedMockDependencyBuilderChainer<TSut>
    :
        INamedMockDependencyBuilderChainer<TSut>
{
    private readonly IResultAsserterCreator<TSut> _resultAsserterCreator;
    private INamedMockDependencyBuilderCreator<TSut> _namedMockDependencyBuilderCreator;

    public NamedMockDependencyBuilderChainer(
        IResultAsserterCreator<TSut> resultAsserterCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator
        )
    {
        _resultAsserterCreator = resultAsserterCreator;
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
    }
    
    public IResultAsserter<TSut, TResult> StartResultAsserter<TResult>(
        Func<IAction<TSut>, TResult> func
        )
    {
        return _resultAsserterCreator.Create(
            func
            );
    }

    public INamedMockDependencyBuilder<TSut, TNewDependency> StartNamedMockDependencyBuilder<TNewDependency>(
        string name
        )
        where TNewDependency : class
    {
        return _namedMockDependencyBuilderCreator.Create<TNewDependency>(
            name
            );
    }

    public void Set(INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator)
    {
        _namedMockDependencyBuilderCreator = namedMockDependencyBuilderCreator;
    }
}