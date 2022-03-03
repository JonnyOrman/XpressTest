namespace XpressTest;

public static class ArrangementInitialiser
{
    public static IArrangement Initialise()
    {
        var objectCollection = new ObjectCollection();

        var mockObjectCollection = new MockObjectCollection();

        var dependencyCollection = new DependencyCollection();

        return new Arrangement(
            objectCollection,
            mockObjectCollection,
            dependencyCollection
        );
    }
}
