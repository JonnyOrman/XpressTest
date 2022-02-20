namespace XpressTest;

public static class ArrangementInitialiser
{
    public static IArrangement Initialise()
    {
        var objectCollection = new ObjectCollection();

        var dependencyCollection = new DependencyCollection();

        return new Arrangement(
            objectCollection,
            dependencyCollection
        );
    }
}
