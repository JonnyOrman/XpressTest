using Moq;
using System.Linq.Expressions;

namespace XpressTest;

public class MockDependencyBuilder<TSut, TDependency> :
    IMockDependencyBuilder<TSut, TDependency>
    where TSut : class
    where TDependency : class
{
    private readonly Mock<TDependency> _dependencyMock;
    
    private readonly ITestComposer<TSut> _testComposer;

    public MockDependencyBuilder(
        Mock<TDependency> dependencyMock,
        ITestComposer<TSut> testComposer
        )
    {
        _dependencyMock = dependencyMock;
        _testComposer = testComposer;
    }

    public IDependencyBuilder<TSut> With<TNewDependency>()
    {
        return _testComposer.ComposeDependencyBuilder<TDependency, TNewDependency>(
            _dependencyMock
        );
    }

    public IValueDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency
        )
    {
        return _testComposer.ComposeValueDependencyBuilder(
            _dependencyMock,
            newDependency
        );
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(
        TNewDependency newDependency,
        string name
        )
        where TNewDependency : class
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependencyMock,
            newDependency,
            name
        );
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.ComposeMockDependencyBuilder<TDependency, TNewDependency>(
            _dependencyMock
        );
    }

    public ISutAsserter<TSut> WhenItIsConstructed()
    {
        throw new NotImplementedException();
    }

    public IResultAsserter<TSut, TResult> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            func,
            _testComposer.Arrangement
            );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<TSut> action)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            action,
            _testComposer.Arrangement
        );
    }

    public IVoidAsserter<TSut> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            func,
            _testComposer.Arrangement
        );
    }
    
    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(Func<IArrangement, Expression<Func<TDependency, TResult>>> func)
    {
        var expression = func.Invoke(_testComposer.Arrangement);

        return new MockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _dependencyMock,
            this,
            _testComposer.Arrangement
            );
    }

    public IMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(Expression<Func<TDependency, TResult>> expression)
    {
        return new MockResultDependencyBuilder<TSut, TDependency, TResult>(
            expression,
            _dependencyMock,
            this,
            _testComposer.Arrangement
        );
    }

    public IObjectBuilder<TSut> WithNamedObject<TObject>(string objectName)
    {
        _testComposer.Arrangement.Add(_dependencyMock);
        _testComposer.Arrangement.AddDependency(_dependencyMock.Object);
        
        var namedObject = _testComposer.GetObject<TObject>(objectName);
        
        _testComposer.Arrangement.AddDependency(namedObject);
        
        return _testComposer.StartNewExistingObjectBuilder(
            _testComposer
        );
    }
}