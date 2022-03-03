namespace XpressTest;

public static class NamedMockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockObjectBuilder<TSut, TObject> Initialise(string mockName)
    {
        var namedMock = NamedMockInitialiser<TObject>.Initialise(mockName);
        
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new NamedMockObjectBuilder<TSut, TObject>(
            namedMock,
            testComposer
        );
    }
}
