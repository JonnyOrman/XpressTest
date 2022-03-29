namespace XpressTest;

public static class ValueDependencyBuilderInitialiser<TSut>
where TSut : class
{
    public static IValueDependencyBuilder<TSut> Initialise<TValueDependency>(TValueDependency dependency)
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

        var namedDependencyBuilderCreator = new NamedDependencyBuilderCreator<TSut>(
            arrangement,
            voidAsserterCreator,
            null
        );

        var namedMockDependencyBuilderChainer = new NamedMockDependencyBuilderChainer<TSut>(
            resultAsserterCreator,
            null
            );

        var namedMockDependencyBuilderCreator = new NamedMockDependencyBuilderCreator<TSut>(
            namedMockDependencyBuilderChainer,
            arrangement
        );

        namedMockDependencyBuilderChainer.Set(namedMockDependencyBuilderCreator);

        var sutAsserterCreator = new SutAsserterCreator<TSut>(
            sutComposer,
            arrangement
        );

        var mockObjectBuilderCreator = new MockObjectBuilderCreator<TSut>(
            arrangement,
            sutAsserterCreator,
            voidAsserterCreator,
            null,
            namedMockDependencyBuilderCreator,
            null
        );
        
        var objectBuilderChainer = new ObjectBuilderChainer<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            null,
            null,
            null,
            mockObjectBuilderCreator
        );

        var namedObjectBuilderChainer = new NamedObjectBuilderChainer<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            null,
            mockObjectBuilderCreator,
            null
            );

        var existingObjectBuilder = new ExistingObjectBuilder<TSut>(
            voidAsserterCreator,
            null,
            null
            );
        
        var objectBuilderCreator = new ObjectBuilderCreator<TSut>(
            arrangement,
            objectBuilderChainer,
            namedObjectBuilderChainer,
            existingObjectBuilder
        );
        
        objectBuilderChainer.Set(objectBuilderCreator);
        mockObjectBuilderCreator.Set(objectBuilderCreator);
        existingObjectBuilder.Set(objectBuilderCreator);
        namedObjectBuilderChainer.Set(objectBuilderCreator);
        
        var mockDependencyBuilderChainer = new MockDependencyBuilderChainer<TSut>(
            asserterCreator,
            namedDependencyBuilderCreator,
            objectBuilderCreator,
            null,
            null
        );
        
        var moqMockDependencyBuilderCreator = new MoqMockDependencyBuilderCreator<TSut>(
            arrangement,
            mockDependencyBuilderChainer,
            namedMockDependencyBuilderChainer
        );

        var mockDependencyBuilderCreator = new MockDependencyBuilderCreator<TSut>(
            arrangement,
            moqMockDependencyBuilderCreator
        );
        
        namedDependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        mockDependencyBuilderChainer.Set(mockDependencyBuilderCreator);
        objectBuilderChainer.Set(mockDependencyBuilderCreator);
        existingObjectBuilder.Set(mockDependencyBuilderCreator);
        mockObjectBuilderCreator.Set(mockDependencyBuilderCreator);
        namedObjectBuilderChainer.Set(mockDependencyBuilderCreator);
        
        var setter = DependencySetterInitialiser<TValueDependency>.Initialise(
            arrangement
            );

        var valueDependencyBuilderCreator = new ValueDependencyBuilderCreator<TSut>(
            arrangement,
            sutAsserterCreator,
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            namedMockDependencyBuilderCreator
        );

        mockDependencyBuilderChainer.Set(valueDependencyBuilderCreator);
        objectBuilderChainer.Set(valueDependencyBuilderCreator);

        var dependencyBuilderChainer = new ValueDependencyBuilderChainer<TSut>(
            sutAsserterCreator,
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            namedMockDependencyBuilderCreator,
            valueDependencyBuilderCreator
        );
        
        return new ValueDependencyBuilder<TSut, TValueDependency>(
            dependency,
            setter,
            dependencyBuilderChainer
        );
    }
}