namespace XpressTest;

public class NamedObjectBuilder<TSut, TObject>
    :
        IObjectBuilder<TSut>
    where TSut : class
{
    private readonly INamedObject<TObject> _namedObject;
    private readonly ITestComposer<TSut> _testComposer;
    private readonly IResultAsserterComposer<TSut> _resultAsserterComposer;
    private readonly INamedObjectSetter<TObject> _namedObjectSetter;

    public NamedObjectBuilder(
        INamedObject<TObject> namedObject,
        ITestComposer<TSut> testComposer,
        IResultAsserterComposer<TSut> resultAsserterComposer,
        INamedObjectSetter<TObject> namedObjectSetter
        )
    {
        _namedObject = namedObject;
        _testComposer = testComposer;
        _resultAsserterComposer = resultAsserterComposer;
        _namedObjectSetter = namedObjectSetter;
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name)
    {
        var newNamedObject = new NamedObject<TNewObject>(
            obj,
            name
        );
        
        _namedObjectSetter.Set(_namedObject);

        return _testComposer.StartNewNamedObjectBuilder(
            newNamedObject
            );
    }

    public IObjectBuilder<TSut> With<TNamedObject>(
        string objectName
        )
    {
        _namedObjectSetter.Set(_namedObject);
        
        var namedObject = _testComposer.GetObject<TNamedObject>(objectName);
        
        _testComposer.Arrangement.AddDependency(namedObject);
        
        return _testComposer.StartNewExistingObjectBuilder(
            _testComposer
            );
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        _namedObjectSetter.Set(_namedObject);

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
        var newNamedObject = new NamedObject<TNewDependency>(
            newDependency,
            name
        );
        
        _namedObjectSetter.Set(_namedObject);
        
        return _testComposer.StartNewNamedObjectBuilder(
            newNamedObject
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        _namedObjectSetter.Set(_namedObject);
        
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency>();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }
}