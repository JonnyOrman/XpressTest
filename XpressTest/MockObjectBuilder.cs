using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockObjectBuilder<TSut, TObject> : IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly Mock<TObject> _mockObject;

    private readonly string _name;

    private readonly IObjectCollection _objectCollection;

    private readonly ITestComposer<TSut> _testComposer;

    public MockObjectBuilder(
        Mock<TObject> mockObject,
        string name,
        IObjectCollection objectCollection,
        ITestComposer<TSut> testComposer
        )
    {
        _mockObject = mockObject;
        _name = name;
        _objectCollection = objectCollection;
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
        var mockObject = new MockObject<TObject>(_mockObject, _name);
        
        _objectCollection.Add(mockObject);

        var mock = new Mock<TNewDependency>();

        var dependencyCollection = new DependencyCollection();

        var arrangement = new Arrangement(
            _objectCollection,
            dependencyCollection
        );

        return new MockDependencyBuilder<TSut, TNewDependency>(
            mock,
            arrangement,
            _testComposer
        );
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