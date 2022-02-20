namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockObjectBuilder<TSut, TObject> AndA<TObject>(string name)
        where TObject : class
    {
        return MockObjectTestInitialiser<TSut, TObject>.Initialise(name);
    }

    public static IObjectBuilder<TSut> And<TObject>(TObject obj, string name)
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
    
    public static IAsserter<System.Action<IArrangement>> WhenIt(System.Action<IAction<TSut>> action)
    {
        return ActionInitialiser<TSut>.Initialise(action);
    }
    
    public static IAsserter<System.Action<IAssertion<TSut, TResult>>> WhenIt<TResult>(Func<IAction<TSut>, TResult> func)
    {
        return ResultActionInitialiser<TSut>.Initialise(func);
    }
}