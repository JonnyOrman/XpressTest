namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockObjectBuilder<TSut, TObject> AndGivenA<TObject>(string name)
        where TObject : class
    {
        return NamedMockObjectTestInitialiser<TSut, TObject>.Initialise(name);
    }
    
    public static IMockObjectBuilder<TSut, TObject> AndGivenA<TObject>()
        where TObject : class
    {
        return MockObjectTestInitialiser<TSut, TObject>.Initialise();
    }

    public static IObjectBuilder<TSut> AndGiven<TObject>(TObject obj, string name)
    {
        return NamedObjectTestInitialiser<TSut, TObject>.Initialise(obj, name);
    }

    public static IObjectBuilder<TSut> AndGiven<TObject>(TObject obj)
    {
        return ObjectTestInitialiser<TSut, TObject>.Initialise(obj);
    }

    public static IMockDependencyBuilder<TSut, TDependency> WithA<TDependency>()
        where TDependency : class
    {
        return MockDependencyTestInitialiser<TSut>.Initialise<TDependency>();
    }
    
    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency)
        where TDependency : class
    {
        return DependencyTestInitialiser<TSut>.Initialise(dependency);
    }
    
    public static ISimpleAsserter WhenIt(System.Action<TSut> action)
    {
        return VoidActionInitialiser<TSut>.Initialise(action);
    }

    public static ISimpleAsserter WhenIt<TResult>(Func<TSut, TResult> func)
    {
        return ResultActionInitialiser<TSut>.Initialise(func);
    }

    public static TSut WhenIt()
    {
        return Activator.CreateInstance<TSut>();
    }
}