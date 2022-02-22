using Moq;

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

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency)
    {
        return _testComposer.ComposeDependencyBuilder(
            _dependencyMock,
            newDependency,
            null
        );
    }

    public IDependencyBuilder<TSut> With<TNewDependency>(TNewDependency newDependency, string name)
    {
        throw new NotImplementedException();
    }

    public IMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>() where TNewDependency : class
    {
        return _testComposer.ComposeMockDependencyBuilder<TDependency, TNewDependency>(
            _dependencyMock
        );
    }

    public IMockDependencyBuilder<TSut, TDependency> ThatDoes<TDependencyResult>(
        Func<IArrangement, MockSetup<TDependency, TDependencyResult>> func
        )
    {
        var result = func.Invoke(_testComposer.Arrangement);

         _dependencyMock.Setup(result.When).Returns(result.Then);
         
         return this;
    }

    public IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            func,
            _testComposer.Arrangement
            );
    }

    public IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> func)
    {
        return _testComposer.ComposeMockAsserter(
            _dependencyMock,
            func,
            _testComposer.Arrangement
        );
    }
}