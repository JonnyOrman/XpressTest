namespace XpressTest;

public static class MockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockSetupBuilder<TSut, TObject> Initialise()
    {
        var container = ContainerComposer<TSut>.Compose();

        return container.MockSetupBuilderGenerator.Create<TObject>();
    }
}