using Moq;

namespace XpressTest;

public class ObjectBuilder<TSut, TObject> : IObjectBuilder<TSut>
    where TSut : class
{
    private readonly TObject _obj;

    private readonly string _name;

    private readonly IObjectCollection _objectCollection;

    private readonly ITestComposer<TSut> _testComposer;

    public ObjectBuilder(
        TObject obj,
        string name,
        IObjectCollection objectCollection,
        ITestComposer<TSut> testComposer
        )
    {
        _obj = obj;
        _name = name;
        _objectCollection = objectCollection;
        _testComposer = testComposer;
    }

    public IObjectBuilder<TSut> AndA<TNewObject>()
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> And<TNewObject>()
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndA<TNewObject>(string name)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> And<TNewObject>(TNewObject obj, string name)
    {
        var objct = new Object<TObject>(
            _obj,
            _name
            );
        
        _objectCollection.Add(objct);
        
        var builder = new ObjectBuilder<TSut, TNewObject>(
            obj,
            name,
            _objectCollection,
            _testComposer
        );

        return builder;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        var obj = new Object<TObject>(
            _obj,
            _name
            );
        
        _objectCollection.Add(obj);

        var dependencyCollection = new DependencyCollection();

        var arrangement = new Arrangement(
            _objectCollection,
            dependencyCollection
            );

        var sutComposer = new SutComposer<TSut>(
            arrangement
        );
        
        var actionExecutor = new ResultActionExecutor<TSut, TResult>(
            func
            );

        var sutTesterComposer = new SutTesterComposer<TSut, IAssertion<TSut, TResult>>(
            actionExecutor,
            arrangement
        );

        var builder = new ResultAsserter<TSut, TResult>(
            sutComposer,
            sutTesterComposer
        );

        return builder;
    }

    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        throw new NotImplementedException();
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        var objct = new Object<TObject>(
            _obj,
            _name
        );
        
        _objectCollection.Add(objct);
        
        var dependencyMock = new Mock<TNewDependency>();

        var dependencyCollection = new DependencyCollection();

        var arrangement = new Arrangement(
            _objectCollection,
            dependencyCollection
            );

        var builder = new MockDependencyBuilder<TSut, TNewDependency>(
            dependencyMock,
            arrangement,
            _testComposer
        );

        return builder;
    }
}