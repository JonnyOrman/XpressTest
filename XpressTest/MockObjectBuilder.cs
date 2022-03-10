using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockObjectBuilder<TSut, TObject>
    :
        IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly Mock<TObject> _mock;
    private readonly ITestComposer<TSut> _testComposer;
    private readonly IMockObjectSetter<TObject> _mockObjectSetter;

    public MockObjectBuilder(
        Mock<TObject> mock,
        ITestComposer<TSut> testComposer,
        IMockObjectSetter<TObject> mockObjectSetter
        )
    {
        _mock = mock;
        _testComposer = testComposer;
        _mockObjectSetter = mockObjectSetter;
    }
    
    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        throw new NotImplementedException();
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

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
        where TNewDependency : class
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        _mockObjectSetter.Set(_mock);
        
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency>();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
    {
        _mockObjectSetter.Set(_mock);
        
        return _testComposer.StartNewMockObjectBuilder<TNewObject>();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> AndGiven<TNewObject>(TNewObject obj, string name)
    {
        throw new NotImplementedException();
    }

    public IObjectBuilder<TSut> With<TObject1>(string objectName)
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TObject> That<TObjectResult>(Expression<Func<TObject, TObjectResult>> func, TObjectResult objectResult)
    {
        throw new NotImplementedException();
    }
}