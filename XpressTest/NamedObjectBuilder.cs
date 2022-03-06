namespace XpressTest;

public class NamedObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
    where TSut : class
{
    private readonly INamedObject<TObject> _namedObject;
    private readonly ITestComposer<TSut> _testComposer;
    private readonly IResultAsserterComposer<TSut> _resultAsserterComposer;

    public NamedObjectBuilder(
        INamedObject<TObject> namedObject,
        ITestComposer<TSut> testComposer,
        IResultAsserterComposer<TSut> resultAsserterComposer
        )
    {
        _namedObject = namedObject;
        _testComposer = testComposer;
        _resultAsserterComposer = resultAsserterComposer;
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>()
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGivenA<TNewObject>(string name)
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

        return _testComposer.StartNewNamedObjectBuilder(_namedObject, newNamedObject);
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        _testComposer.Arrangement.Add(_namedObject);

        return _resultAsserterComposer.Compose(
            func,
            _testComposer.Arrangement
            );
    }
    
    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
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
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency, TObject>(_namedObject);
    }
}