using System.Linq.Expressions;

namespace XpressTest;

public class NamedMockObjectBuilder<TSut, TObject>
    :
        IMockObjectBuilder<TSut, TObject>
    where TSut : class
    where TObject : class
{
    private readonly INamedMock<TObject> _namedMock;
    
    private readonly ITestComposer<TSut> _testComposer;
    private readonly INamedMockObjectSetter<TObject> _namedMockObjectSetter;

    public NamedMockObjectBuilder(
        INamedMock<TObject> namedMock,
        ITestComposer<TSut> testComposer,
        INamedMockObjectSetter<TObject> namedMockObjectSetter
        )
    {
        _namedMock = namedMock;
        _testComposer = testComposer;
        _namedMockObjectSetter = namedMockObjectSetter;
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

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>()
        where TNewDependency : class
    {
        _namedMockObjectSetter.Set(_namedMock);
        
        return _testComposer.StartNewMockDependencyBuilder<TNewDependency>();
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TNewObject> AndGivenA<TNewObject>()
        where TNewObject : class
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

    public IObjectBuilder<TSut> With<TObject1>(string objectName)
    {
        throw new NotImplementedException();
    }

    public IMockObjectBuilder<TSut, TObject> That<TObjectResult>(Expression<Func<TObject, TObjectResult>> func, TObjectResult objectResult)
    {
        throw new NotImplementedException();
    }
}