namespace XpressTest;

public static class ContainerComposer<TSut>
where TSut : class
{
    public static IContainer<TSut> Compose()
    {
        var arrangement = ArrangementInitialiser.Initialise();

        return Compose(arrangement);
    }
    
    public static IContainer<TSut> Compose(IArrangement arrangement)
    {
        var asserterCreator = AsserterCreatorInitialiser<TSut>.Initialise(arrangement);
        
        var testBuilderContainer = new TestBuilderContainer<TSut>(
            asserterCreator
            );

        var dependencyBuilderChainer = new DependencyBuilderChainer<TSut>(
            arrangement,
            testBuilderContainer
        );

        var mockSetupBuilderGenerator = new MockSetupBuilderCreator<TSut>(
            testBuilderContainer,
            arrangement,
            null
        );
        
        var namedMockSetupBuilderCreator = new NamedMockSetupBuilderCreator<TSut>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderGenerator
        );

        mockSetupBuilderGenerator.Set(namedMockSetupBuilderCreator);

        var variableBuilderCreator = new VariableBuilderCreator<TSut>(
            testBuilderContainer,
            arrangement,
            mockSetupBuilderGenerator,
            namedMockSetupBuilderCreator
        );
        
        testBuilderContainer.VariableBuilderCreator = variableBuilderCreator;
        
        var objectDependencyBuilderCreator = new ObjectDependencyBuilderCreator<TSut>(
            testBuilderContainer,
            arrangement
        );

        var namedDependencyBuilderCreator = new NamedDependencyBuilderCreator<TSut>(
            arrangement,
            dependencyBuilderChainer
        );

        var moqMockDependencyBuilderCreator = new MoqMockDependencyBuilderCreator<TSut>(
            arrangement,
            dependencyBuilderChainer
        );

        var mockDependencyBuilderCreator = new MockDependencyBuilderCreator<TSut>(
            arrangement,
            moqMockDependencyBuilderCreator
        );

        var namedMockDependencyBuilderCreator = new NamedMockDependencyBuilderCreator<TSut>(
            arrangement,
            dependencyBuilderChainer
        );

        var existingObjectDependencyBuilderCreator = new ExistingObjectDependencyBuilderCreator<TSut>(
            testBuilderContainer,
            arrangement
        );

        var dependencyBuilderCreator = new DependencyBuilderCreator<TSut>(
            objectDependencyBuilderCreator,
            namedDependencyBuilderCreator,
            mockDependencyBuilderCreator,
            namedMockDependencyBuilderCreator,
            existingObjectDependencyBuilderCreator
        );

        testBuilderContainer.DependencyBuilderCreator = dependencyBuilderCreator;

        return new Container<TSut>(
            objectDependencyBuilderCreator,
            mockSetupBuilderGenerator,
            moqMockDependencyBuilderCreator,
            namedDependencyBuilderCreator,
            namedMockSetupBuilderCreator,
            testBuilderContainer
            );
    }
}