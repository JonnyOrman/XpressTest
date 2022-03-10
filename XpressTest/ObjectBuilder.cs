namespace XpressTest;

public class ObjectBuilder<TSut, TObject>
    :
        IObjectBuilder<TSut>
    where TSut : class
{
    private readonly TObject _obj;
    private readonly ITestComposer<TSut> _testComposer;
    private readonly IResultAsserterComposer<TSut> _resultAsserterComposer;
    private readonly IObjectSetter<TObject> _objectSetter;

    public ObjectBuilder(
        TObject obj,
        ITestComposer<TSut> testComposer,
        IResultAsserterComposer<TSut> resultAsserterComposer,
        IObjectSetter<TObject> objectSetter
        )
    {
        _obj = obj;
        _testComposer = testComposer;
        _resultAsserterComposer = resultAsserterComposer;
        _objectSetter = objectSetter;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        _objectSetter.Set(_obj);

        return _resultAsserterComposer.Compose(
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
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>()
    {
        _objectSetter.Set(_obj);
        
        return _testComposer.ComposeValueDependencyBuilder<TObject, TNewDependency>();
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        _objectSetter.Set(_obj);
        
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency>();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj)
    {
        _objectSetter.Set(_obj);
        
        return _testComposer.StartNewObjectBuilder(
            obj
            );
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> With<TNamedObject>(string objectName)
    {
        _objectSetter.Set(_obj);
        
        var namedObject = _testComposer.GetObject<TNamedObject>(objectName);
        
        return _testComposer.StartNewObjectBuilder(
            namedObject
        );
    }
}
