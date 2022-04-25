namespace XpressTest;

public static class VariableTestInitialiser<TSut, TObject>
where TSut : class
{
    public static IVariableBuilder<TSut> Initialise(
        TObject obj,
        IArrangement arrangement,
        IArrangementSetter<TObject> objectSetter
        )
    {
        var container = ContainerComposer<TSut>.Compose(
            arrangement
            );
        
        var variableBuilderChainer = new VariableBuilderChainer<TSut>(
            container.TestBuilderContainer,
            container.MockSetupBuilderCreator,
            container.NamedMockSetupBuilderCreator
        );
        
        return new VariableBuilder<TSut, TObject, IVariableBuilderChainer<TSut>>(
            obj,
            objectSetter,
            variableBuilderChainer
        );
    }
}