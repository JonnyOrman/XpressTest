using Moq;

namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockObjectBuilder<TSut, TObject> AndA<TObject>(string name)
        where TObject : class
    {
        var objectMock = new Mock<TObject>();

        var objects = new ObjectCollection();
        
        var builder = new MockObjectBuilder<TSut, TObject>(
            objectMock,
            name,
            objects
            );

        return builder;
    }

    public static IObjectBuilder<TSut> And<TObject>(TObject obj, string name)
    {
        var builder = new ObjectBuilder<TSut, TObject>(
            obj,
            name,
            new ObjectCollection()
            );

        return builder;
    }
    
    public static IMockDependencyBuilder<TSut, TDependency> WithA<TDependency>()
        where TDependency : class
    {
        var dependencyMock = new Mock<TDependency>();

        var dependencies = new DependencyCollection();

        var objects = new ObjectCollection();
        
        var builder = new MockDependencyBuilder<TSut, TDependency>(
            dependencyMock,
            dependencies,
            objects
            );

        return builder;
    }
    
    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency)
    {
        var builder = new DependencyBuilder<TSut, TDependency>(
            dependency,
            new DependencyCollection(),
            new ObjectCollection()
            );
        
        return builder;
    }
    
    public static IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> action)
    {
        var dependencies = new DependencyCollection();
        
        var objects = new ObjectCollection();
        
        var builder = new VoidAsserter<TSut>(
            action,
            dependencies,
            objects
            );

        return builder;
    }
    
    public static IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        var dependencies = new DependencyCollection();
        
        var objects = new ObjectCollection();
        
        var builder = new ResultAsserter<TSut, TResult>(
            func,
            dependencies,
            objects
        );

        return builder;
    }
}