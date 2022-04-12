namespace XpressTest;

public static class NamedMockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockSetupBuilder<TSut, TObject> Initialise(string mockName)
    {
        var container = ContainerComposer<TSut>.Compose();
        
        return container.NamedMockSetupBuilderCreator.Create<TObject>(mockName);
    }
}
