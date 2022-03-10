namespace XpressTest;

public class DependencyBuilder<TSut, TDependency> :
    IDependencyBuilder<TSut>
    where TSut : class
    where TDependency : class
{
    private readonly TDependency _dependency;
    
    private readonly ITestComposer<TSut> _testComposer;

    public DependencyBuilder(
        TDependency dependency,
        ITestComposer<TSut> testComposer
            )
    {
        _dependency = dependency;
        _testComposer = testComposer;
    }

    public IDependencyBuilder<TSut> With<TNewDependency>()
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependency,
            newDependency
        );
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependency,
            newDependency,
            name
        );
    }
    
    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.ComposeMockDependencyBuilder<TDependency, TNewDependency>(
            _dependency
        );
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            _testComposer.Arrangement
        );
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            func,
            _testComposer.Arrangement
        );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            func,
            _testComposer.Arrangement
        );
    }
}