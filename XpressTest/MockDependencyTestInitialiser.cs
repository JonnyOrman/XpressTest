using Moq;

namespace XpressTest;

public static class MockDependencyTestInitialiser<TSut>
    where TSut : class
{
    public static IMockDependencyBuilder<TSut, TDependency> Initialise<TDependency>()
    where TDependency : class
    {
        var dependencyMock = new Mock<TDependency>();

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

        var sutAsserterCreator = new SutAsserterCreator<TSut>(
            sutComposer,
            arrangement
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
        
        var valueDependencyBuilderCreator = new ValueDependencyBuilderCreator<TSut>(
            arrangement,
            sutAsserterCreator,
            voidAsserterCreator,
            null,
            namedMockDependencyBuilderCreator
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
            valueDependencyBuilderCreator,
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
            valueDependencyBuilderCreator,
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
        valueDependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        
        var mockDependencySetter = new MockDependencySetter<TDependency>(
            arrangement
        );

        var mockObjectBuilderChainer = new MockDependencyBuilderChainer<TSut>(
            asserterCreator,
            namedDependencyBuilderCreator,
            objectBuilderCreator,
            valueDependencyBuilderCreator,
            mockDependencyBuilderCreator
        );
        
        return new MockDependencyBuilder<TSut, TDependency>(
            dependencyMock,
            mockDependencySetter,
            mockObjectBuilderChainer,
            arrangement
        );
    }
}
