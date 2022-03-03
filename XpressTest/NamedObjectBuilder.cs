namespace XpressTest;

public class NamedObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
    where TSut : class
{
    private readonly INamedObject<TObject> _namedObject;
    private readonly ITestComposer<TSut> _testComposer;

    public NamedObjectBuilder(
        INamedObject<TObject> namedObject,
        ITestComposer<TSut> testComposer
        )
    {
        _namedObject = namedObject;
        _testComposer = testComposer;
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

        var sutComposer = new SutComposer<TSut>(
            _testComposer.Arrangement
        );

        var sut = sutComposer.Compose();

        var action = new Action<TSut>(
            sut,
            _testComposer.Arrangement
        );

        var result = func.Invoke(action);

        var resultPropertyTargeter = new ResultPropertyTargeter<TResult>(
            result,
            _testComposer.Arrangement
            );


        var builder = new ResultAsserter<TSut, TResult>(
            result,
            sutComposer,
            resultPropertyTargeter
        );

        return builder;
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