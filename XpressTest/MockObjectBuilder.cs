using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockObjectBuilder<TSut, TObject> : IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly Mock<TObject> _mockObject;
    private readonly string _name;
    private readonly IObjectCollection _objects;

    public MockObjectBuilder(
        Mock<TObject> mockObject,
        string name,
        IObjectCollection objects
        )
    {
        _mockObject = mockObject;
        _name = name;
        _objects = objects;
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
        
        _objects.Add(mockObject);

        var mock = new Mock<TNewDependency>();

        return new MockDependencyBuilder<TSut, TNewDependency>(
            mock,
            new DependencyCollection(),
            _objects
        );
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
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TObject> That<TObjectResult>(Expression<Func<TObject, TObjectResult>> func, TObjectResult objectResult)
    {
        throw new NotImplementedException();
    }
}