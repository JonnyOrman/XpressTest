namespace XpressTest;

public static class MockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockObjectBuilder<TSut, TObject> Initialise(string mockName)
    {
        var namedMock = NamedMockInitialiser<TObject>.Initialise(mockName);
        
        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        return new MockObjectBuilder<TSut, TObject>(
            namedMock,
            testComposer
        );
    }
}
