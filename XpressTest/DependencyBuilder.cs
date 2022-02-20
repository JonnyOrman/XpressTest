namespace XpressTest;

public class DependencyBuilder<TSut, TDependency> :
    IDependencyBuilder<TSut>
    where TSut : class
{
    private readonly TDependency _dependency;

    private readonly IArrangement _arrangement;

    private readonly ITestComposer<TSut> _testComposer;

    public DependencyBuilder(
        TDependency dependency,
        IArrangement arrangement,
        ITestComposer<TSut> testComposer
            )
    {
        _dependency = dependency;
        _arrangement = arrangement;
        _testComposer = testComposer;
    }
    
    
    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependency,
            newDependency,
            name,
            _arrangement,
            _testComposer
        );
    }
    
    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.ComposeDependencyBuilder<TDependency, TNewDependency>(
            _dependency,
            _arrangement,
            _testComposer
        );
    }
    
    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            func,
            _arrangement
        );
    }

    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _testComposer.ComposeAsserter(
            _dependency,
            func,
            _arrangement
        );
    }
}