namespace XpressTest;

public class ObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
    where TSut : class
{
    private readonly TObject _obj;
    private readonly ITestComposer<TSut> _testComposer;
    private readonly IResultAsserterComposer<TSut> _resultAsserterComposer;

    public ObjectBuilder(
        TObject obj,
        ITestComposer<TSut> testComposer,
        IResultAsserterComposer<TSut> resultAsserterComposer
        )
    {
        _obj = obj;
        _testComposer = testComposer;
        _resultAsserterComposer = resultAsserterComposer;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        _testComposer.Arrangement.Add(_obj);

        return _resultAsserterComposer.Compose(
            func,
            _testComposer.Arrangement
            );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
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
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency, TObject>(_obj);
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
        return _testComposer.StartNewObjectBuilder(_obj, obj);
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name)
    {
        throw new NotImplementedException();
    }
}
