using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockObjectBuilder<TSut, TObject> : IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly Mock<TObject> _mock;
    private readonly ITestComposer<TSut> _testComposer;

    public MockObjectBuilder(
        Mock<TObject> mock,
        ITestComposer<TSut> testComposer
        )
    {
        _mock = mock;
        _testComposer = testComposer;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        throw new NotImplementedException();
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
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency, TObject>(_mock);
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        return _testComposer.StartNewMockObjectBuilder<TNewObject, TObject>(_mock);
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
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TObject> That<TObjectResult>(Expression<Func<TObject, TObjectResult>> func, TObjectResult objectResult)
    {
        throw new NotImplementedException();
    }
}