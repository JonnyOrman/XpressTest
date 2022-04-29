namespace XpressTest;

public static class ArrangementInitialiser
{
    public static IArrangement Initialise()
    {
        var objectDictionary = new Dictionary<string, object>();

        var objects = new List<object>();

        var objectCollection = new ObjectCollection(
            objectDictionary,
            objects
            );

        var mockObjectDictionary = new Dictionary<string, IMock>();

        var mocks = new List<IMock>();

        var mockObjectCollection = new MockObjectCollection(
            mockObjectDictionary,
            mocks
            );

        var dependencies = new List<IDependency>();

        var dependencyCollection = new DependencyCollection(
            dependencies
            );

        return new Arrangement(
            objectCollection,
            mockObjectCollection,
            dependencyCollection
        );
    }
}
