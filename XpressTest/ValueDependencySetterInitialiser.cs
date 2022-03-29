namespace XpressTest;

public static class ValueDependencySetterInitialiser<TDependency>
{
    public static IObjectSetter<TDependency> Initialise(
        IArrangement arrangement
        )
    {
        return new ValueSetter<TDependency>(
            arrangement
            );
    }
}