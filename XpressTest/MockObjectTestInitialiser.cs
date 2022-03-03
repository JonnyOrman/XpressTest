using Moq;

namespace XpressTest;

public static class MockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockObjectBuilder<TSut, TObject> Initialise()
    {
        var mock = new Mock<TObject>();
        
        var testComposer = TestComposerInitialiser<TSut>.Initialise();
        
        return new MockObjectBuilder<TSut, TObject>(
            mock,
            testComposer
        );
    }
}