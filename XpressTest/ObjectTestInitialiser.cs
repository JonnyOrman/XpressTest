namespace XpressTest;

public static class ObjectTestInitialiser<TSut, TObject>
    where TSut : class
{
    public static IObjectBuilder<TSut> Initialise(TObject obj)
    {
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        var resultAsserterComposer = ResultAsserterComposerInitialiser<TSut>.Initialise();

        var objectSetter = new ObjectSetter<TObject>(
            testComposer.Arrangement
            );
        
        return new ObjectBuilder<TSut, TObject>(
            obj,
            testComposer,
            resultAsserterComposer,
            objectSetter
        );
    }
}
