namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockObjectBuilder<TSut, TObject> AndGivenA<TObject>(string name)
        where TObject : class
    {
        return MockObjectTestInitialiser<TSut, TObject>.Initialise(name);
    }

    public static IObjectBuilder<TSut> AndGiven<TObject>(TObject obj, string name)
    {
        return ObjectTestInitialiser<TSut, TObject>.Initialise(obj, name);
    }
    
    public static IMockDependencyBuilder<TSut, TDependency> WithA<TDependency>()
        where TDependency : class
    {
        return MockDependencyTestInitialiser<TSut>.Initialise<TDependency>();
    }
    
    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency)
    {
        return DependencyTestInitialiser<TSut>.Initialise(dependency);
    }
    
    public static void WhenIt(System.Action<TSut> action)
    {
        ActionInitialiser<TSut>.Initialise(action);
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