namespace XpressTest;

public static class NamedObjectInitialiser<T>
{
    public static INamedObject<T> Initialise(
        T obj,
        string name
        )
    {
        return new NamedObject<T>(
            obj,
            name
            );
    }
}
