using System.Linq.Expressions;

namespace XpressTest;

public class MockObjectBuilder<TSut, TObject> : IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly INamedMock<TObject> _namedMock;
    
    private readonly ITestComposer<TSut> _testComposer;

    public MockObjectBuilder(
        INamedMock<TObject> namedMock,
        ITestComposer<TSut> testComposer
        )
    {
        _namedMock = namedMock;
        _testComposer = testComposer;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        throw new NotImplementedException();
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
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency, TObject>(_namedMock);
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

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name)
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TObject> That<TObjectResult>(Expression<Func<TObject, TObjectResult>> func, TObjectResult objectResult)
    {
        throw new NotImplementedException();
    }
}