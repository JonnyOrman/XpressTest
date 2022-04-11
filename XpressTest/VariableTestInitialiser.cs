namespace XpressTest;

public static class VariableTestInitialiser<TSut, TObject>
where TSut : class
{
    public static IVariableBuilder<TSut> Initialise(
        TObject obj,
        IArrangement arrangement,
        ArrangementSetter<TObject> objectSetter
        )
    {
        var sutComposer = new ArrangementSutComposer<TSut>(
            arrangement
        );

        var resultAsserterCreator = new ResultAsserterCreator<TSut>(
            sutComposer,
            arrangement
        );

        var voidAsserterCreator = new VoidAsserterCreator<TSut>(
            sutComposer,
            arrangement
        );

        var asserterCreator = new AsserterCreator<TSut>(
            voidAsserterCreator,
            resultAsserterCreator
            );

        var sutAsserterCreator = new SutAsserterCreator<TSut>(
            sutComposer,
            arrangement
        );

        var dependencyBuilderCreator = new DependencyBuilderCreator<TSut>(
            null,
            null,
            null,
            null
        );

        var namedMockDependencyBuilderCreator = new NamedMockDependencyBuilderCreator<TSut>(
            null,
            arrangement
        );
        
        var namedDependencyBuilderCreator = new NamedDependencyBuilderCreator<TSut>(
            arrangement,
            null
        );

        var dependencyBuilderChainer = new DependencyBuilderChainer<TSut>(
            asserterCreator,
            null,
            arrangement,
            dependencyBuilderCreator,
            sutAsserterCreator
        );

        namedMockDependencyBuilderCreator.Set(dependencyBuilderChainer);
        namedDependencyBuilderCreator.Set(dependencyBuilderChainer);
        
        var moqMockDependencyBuilderCreator = new MoqMockDependencyBuilderCreator<TSut>(
            arrangement,
            dependencyBuilderChainer
        );
        
        var mockDependencyBuilderCreator = new MockDependencyBuilderCreator<TSut>(
            arrangement,
            moqMockDependencyBuilderCreator
        );
        
        var objectDependencyBuilderCreator = new ObjectDependencyBuilderCreator<TSut>(
            arrangement,
            sutAsserterCreator,
            asserterCreator,
            null,
            dependencyBuilderCreator
        );

        var mockSetupBuilderGenerator = new MockSetupBuilderCreator<TSut>(
            arrangement,
            asserterCreator,
            null,
            dependencyBuilderCreator,
            null,
            sutAsserterCreator
        );
        
        var namedMockSetupBuilderGenerator = new NamedMockSetupBuilderCreator<TSut>(
            arrangement,
            asserterCreator,
            mockSetupBuilderGenerator,
            null,
            dependencyBuilderCreator,
            sutAsserterCreator
        );

        mockSetupBuilderGenerator.Set(namedMockSetupBuilderGenerator);

        var namedObjectBuilderChainer = new VariableBuilderChainer<TSut>(
            asserterCreator,
            null,
            mockSetupBuilderGenerator,
            dependencyBuilderCreator,
            namedMockSetupBuilderGenerator,
            sutAsserterCreator
        );

        var existingObjectDependencyBuilderCreator = new ExistingObjectDependencyBuilderCreator<TSut>(
            arrangement,
            asserterCreator,
            null,
            dependencyBuilderCreator,
            sutAsserterCreator
            );
        
        var objectBuilderCreator = new ObjectBuilderCreator<TSut>(
            arrangement,
            existingObjectDependencyBuilderCreator,
            asserterCreator,
            mockSetupBuilderGenerator,
            dependencyBuilderCreator,
            namedMockSetupBuilderGenerator,
            sutAsserterCreator
        );
        
        dependencyBuilderChainer.Set(objectBuilderCreator);
        namedObjectBuilderChainer.Set(objectBuilderCreator);
        objectDependencyBuilderCreator.Set(objectBuilderCreator);
        namedMockSetupBuilderGenerator.Set(objectBuilderCreator);
        mockSetupBuilderGenerator.Set(objectBuilderCreator);
        existingObjectDependencyBuilderCreator.Set(objectBuilderCreator);

        dependencyBuilderCreator.Set(objectDependencyBuilderCreator);
        dependencyBuilderCreator.Set(namedDependencyBuilderCreator);
        dependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        dependencyBuilderCreator.Set(namedMockDependencyBuilderCreator);
        
        return new VariableBuilder<TSut, TObject, IVariableBuilderChainer<TSut>>(
            obj,
            objectSetter,
            namedObjectBuilderChainer
        );
    }
}