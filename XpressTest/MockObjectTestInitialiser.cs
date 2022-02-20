using Moq;

namespace XpressTest;

public static class MockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockObjectBuilder<TSut, TObject> Initialise(string objectName)
    {
        var objectMock = new Mock<TObject>();

        var objectCollection = new ObjectCollection();

        var testComposer = TestComposerInitialiser<TSut>.Initialise();

        var builder = new MockObjectBuilder<TSut, TObject>(
            objectMock,
            objectName,
            objectCollection,
            testComposer
        );

        return builder;
    }
}
