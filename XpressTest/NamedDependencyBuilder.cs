namespace XpressTest;

public class NamedDependencyBuilder<TSut, TDependency>
    : 
        IDependencyBuilder<TSut>
{
    private readonly TDependency _dependency;
    private readonly string _name;
    private readonly ITestComposer<TSut> _testComposer;

    public NamedDependencyBuilder(
        TDependency dependency,
        string name,
        ITestComposer<TSut> testComposer
        )
    {
        _dependency = dependency;
        _name = name;
        _testComposer = testComposer;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            action,
            _testComposer.Arrangement
        );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>()
    {
        throw new NotImplementedException();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependency,
            _name,
            newDependency,
            name
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.ComposeMockDependencyBuilder<TDependency, TNewDependency>(
            _dependency,
            _name
        );
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }
}