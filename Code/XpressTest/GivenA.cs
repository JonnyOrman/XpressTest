namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockSetupBuilder<TSut, TObject> AndGivenA<TObject>(string name)
        where TObject : class
    {
        return NamedMockObjectTestInitialiser<TSut, TObject>.Initialise(
            name
            );
    }

    public static IMockSetupBuilder<TSut, TObject> AndGivenA<TObject>()
        where TObject : class
    {
        return MockObjectTestInitialiser<TSut, TObject>.Initialise();
    }

    public static IVariableBuilder<TSut> AndGiven<TObject>(TObject obj, string name)
    {
        return NamedObjectTestInitialiser<TSut, TObject>.Initialise(
            obj,
            name
            );
    }

    public static IVariableBuilder<TSut> AndGiven<TObject>(TObject obj)
    {
        return ObjectTestInitialiser<TSut, TObject>.Initialise(
            obj
            );
    }

    public static IMockDependencySetupBuilder<TSut, TDependency> WithA<TDependency>()
        where TDependency : class
    {
        return MockDependencyTestInitialiser<TSut>.Initialise<TDependency>();
    }

    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency)
    {
        return ObjectDependencyBuilderInitialiser<TSut>.Initialise(
            dependency
        );
    }

    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency, string name)
    {
        return NamedDependencyTestInitialiser<TSut>.Initialise(
            dependency,
            name
            );
    }

    public static IExceptionAsserter WhenIt(Action<TSut> action)
    {
        return VoidExceptionAsserterInitialiser<TSut>.Initialise(
            action
        );
    }

    public static ISimpleResultAsserter<TResult> WhenIt<TResult>(Func<TSut, TResult> func)
    {
        return SimpleResultAsserterInitialiser<TSut>.Initialise(
            func
        );
    }

    public static TSut WhenIt()
    {
        return Activator.CreateInstance<TSut>();
    }

    public static ISutPropertyTargeter<TSut> WhenItIsConstructed()
    {
        return SutActionInitialiser<TSut>.Initialise();
    }
}