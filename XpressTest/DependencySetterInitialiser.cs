namespace XpressTest;

public static class DependencySetterInitialiser<TDependency>
{
    public static IArrangementSetter<TDependency> Initialise(
        IArrangement arrangement
        )
    {
        return new DependencySetter<TDependency>(
            arrangement
            );
    }
}