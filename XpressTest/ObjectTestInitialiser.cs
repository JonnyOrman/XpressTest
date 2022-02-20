namespace XpressTest;

public static class ObjectTestInitialiser<TSut, TObject>
    where TSut : class
{
    public static IObjectBuilder<TSut> Initialise(
        TObject obj,
        string objectName
        )
    {
        var objectCollection = new ObjectCollection();

        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        var builder = new ObjectBuilder<TSut, TObject>(
            obj,
            objectName,
            objectCollection,
            testComposer
        );

        return builder;
    }
}
