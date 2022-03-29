namespace XpressTest;

public static class DependencySetterInitialiser<TDependency>
{
    public static IObjectSetter<TDependency> Initialise(
        IArrangement arrangement
        )
    {
        return new DependencySetter<TDependency>(
            arrangement
            );
    }
}