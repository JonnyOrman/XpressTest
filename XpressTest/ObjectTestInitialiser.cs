namespace XpressTest;

public static class ObjectTestInitialiser<TSut, TObject>
    where TSut : class
{
    public static IObjectBuilder<TSut> Initialise(
        TObject obj,
        string objectName
        )
    {
        var namedObject = NamedObjectInitialiser<TObject>.Initialise(
            obj,
            objectName
        );

        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new ObjectBuilder<TSut, TObject>(
            namedObject,
            testComposer
        );
    }
}
