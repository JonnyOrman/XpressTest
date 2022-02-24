namespace XpressTest;

public class ObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
    where TSut : class
{
    private readonly TObject _obj;
    private readonly ITestComposer<TSut> _testComposer;

    public ObjectBuilder(
        TObject obj,
        ITestComposer<TSut> testComposer
        )
    {
        _obj = obj;
        _testComposer = testComposer;
    }
    
    public IAsserter<System.Action<IAssertion<TSut, TResult>>, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        _testComposer.Arrangement.Add(_obj);

        var sutComposer = new SutComposer<TSut>(
            _testComposer.Arrangement
        );

        var actionExecutor = new ResultActionExecutor<TSut, TResult>(
            func
            );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut, TResult>>(
            actionExecutor,
            _testComposer.Arrangement
        );


        var sut = sutComposer.Compose();

        var action = new Action<TSut>(
            sut,
            _testComposer.Arrangement
        );

        var result = func.Invoke(action);

        var resultPropertyTargeter = new ResultPropertyTargeter<TResult>(result);



        var builder = new ResultAsserter<TSut, TResult>(
            sutComposer,
            sutTesterComposer,
            resultPropertyTargeter
        );

        return builder;

        
    }

    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency, TObject>(_obj);
    }

    public IObjectBuilder<TSut> AndGivenA<TNewObject>()
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
