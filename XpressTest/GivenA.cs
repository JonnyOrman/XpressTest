using Moq;

namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockDependencyBuilder<TSut, TDependency> WithA<TDependency>()
        where TDependency : class
    {
        var dependencyMock = new Mock<TDependency>();

        var dependencies = new List<IDependency>();
        
        var builder = new MockDependencyBuilder<TSut, TDependency>(
            dependencyMock,
            dependencies
            );

        return builder;
    }
    
    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency)
    {
        var builder = new DependencyBuilder<TSut, TDependency>(
            dependency,
            new List<IDependency>()
            );
        
        return builder;
    }
    
    public static IAsserter<Action> WhenIt(Action<TSut> action)
    {
        var dependencies = new List<IDependency>();
        
        var builder = new VoidAsserter<TSut>(
            action,
            dependencies
            );

        return builder;
    }
    
    public static IAsserter<Action<TResult>> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        var dependencies = new List<IDependency>();
        
        var builder = new ResultAsserter<TSut, TResult>(
            func,
            dependencies
        );

        return builder;
    }
}