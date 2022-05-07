using System.Linq.Expressions;
using XpressTest.Narration;

namespace XpressTest;

public static class GivenA<TSut>
    where TSut : class
{
    public static IMockSetupBuilder<TSut, TObject> AndGivenA<TObject>(string name)
        where TObject : class
    {
        var narration = NarrationInitialiser<TSut>.Initialise();

        var actionNarrator = new NamedVariableNarrator(name);
        actionNarrator.Narrate();
        
        return NamedMockObjectTestInitialiser<TSut, TObject>.Initialise(
            name
            );
    }

    public static IMockSetupBuilder<TSut, TObject> AndGivenA<TObject>()
        where TObject : class
    {
        NarrationInitialiser<TSut>.Initialise();
        
        return MockObjectTestInitialiser<TSut, TObject>.Initialise();
    }

    public static IVariableBuilder<TSut> AndGiven<TObject>(TObject obj, string name)
    {
        NarrationInitialiser<TSut>.Initialise();

        return NamedObjectTestInitialiser<TSut, TObject>.Initialise(
            obj,
            name
            );
    }

    public static IVariableBuilder<TSut> AndGiven<TObject>(TObject obj)
    {
        NarrationInitialiser<TSut>.Initialise();

        return ObjectTestInitialiser<TSut, TObject>.Initialise(
            obj
            );
    }

    public static IMockDependencySetupBuilder<TSut, TDependency> WithA<TDependency>()
        where TDependency : class
    {
        NarrationInitialiser<TSut>.Initialise();

        return MockDependencyTestInitialiser<TSut>.Initialise<TDependency>();
    }

    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency)
    {
        NarrationInitialiser<TSut>.Initialise();

        return ObjectDependencyBuilderInitialiser<TSut>.Initialise(
            dependency
        );
    }

    public static IDependencyBuilder<TSut> With<TDependency>(TDependency dependency, string name)
    {
        NarrationInitialiser<TSut>.Initialise();

        return NamedDependencyTestInitialiser<TSut>.Initialise(
            dependency,
            name
            );
    }

    public static IExceptionAsserter WhenIt(Action<TSut> action)
    {
        NarrationInitialiser<TSut>.Initialise();

        return VoidExceptionAsserterInitialiser<TSut>.Initialise(
            action
        );
    }

    public static ISimpleResultAsserter<TResult> WhenIt<TResult>(Expression<Func<TSut, TResult>> func)
    {
        var narration = NarrationInitialiser<TSut>.Initialise();

        var actionNarrator = new ActionNarrator<TSut, TResult>();
        actionNarrator.Narrate(func);

        return SimpleResultAsserterInitialiser<TSut>.Initialise(
            func,
            narration
        );
    }

    public static TSut WhenIt()
    {
        NarrationInitialiser<TSut>.Initialise();

        return Activator.CreateInstance<TSut>();
    }

    public static ISutPropertyTargeter<TSut> WhenItIsConstructed()
    {
        NarrationInitialiser<TSut>.Initialise();

        return SutActionInitialiser<TSut>.Initialise();
    }
}