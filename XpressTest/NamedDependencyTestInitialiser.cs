namespace XpressTest;

public static class NamedDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IDependencyBuilder<TSut> Initialise<TDependency>(
        TDependency dependency,
        string name
        )
    {
        var arrangement = ArrangementInitialiser.Initialise();

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

        namedObjectBuilderChainer.Set(objectBuilderCreator);
        namedObjectBuilderChainer.Set(objectBuilderCreator);
        objectDependencyBuilderCreator.Set(objectBuilderCreator);
        namedMockSetupBuilderGenerator.Set(objectBuilderCreator);
        existingObjectDependencyBuilderCreator.Set(objectBuilderCreator);
        
        var dependencyBuilderChainer = new DependencyBuilderChainer<TSut>(
            asserterCreator,
            objectBuilderCreator,
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
        
        dependencyBuilderCreator.Set(objectDependencyBuilderCreator);
        dependencyBuilderCreator.Set(namedDependencyBuilderCreator);
        dependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        dependencyBuilderCreator.Set(namedMockDependencyBuilderCreator);

        return namedDependencyBuilderCreator.Create(
            dependency,
            name
        );
    }
}