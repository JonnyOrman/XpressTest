namespace XpressTest;

public static class NamedObjectTestInitialiser<TSut, TObject>
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

        var resultAsserterComposer = ResultAsserterComposerInitialiser<TSut>.Initialise();

        var namedObjectSetter = new NamedObjectSetter<TObject>(
            testComposer.Arrangement
            );
        
        return new NamedObjectBuilder<TSut, TObject>(
            namedObject,
            testComposer,
            resultAsserterComposer,
            namedObjectSetter
        );
    }
}
