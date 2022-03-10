namespace XpressTest;

public class ExistingObjectBuilder<TSut>
    :
        IObjectBuilder<TSut>
{
    private readonly ITestComposer<TSut> _testComposer;

    public ExistingObjectBuilder(
        
        ITestComposer<TSut> testComposer
        )
    {
        _testComposer = testComposer;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        throw new NotImplementedException();
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return _testComposer.ComposeAsserter(
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

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name) where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency>();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>() where TNewObject : class
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> With<TNamedObject>(string objectName)
    {
        var namedObject = _testComposer.GetObject<TNamedObject>(objectName);
        
        _testComposer.Arrangement.AddDependency(namedObject);
        
        return _testComposer.StartNewExistingObjectBuilder(
            _testComposer
        );
    }
}