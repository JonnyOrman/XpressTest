using Moq;

namespace XpressTest;

public static class MockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static IMockObjectBuilder<TSut, TObject> Initialise()
    {
        var mock = new Mock<TObject>();

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
        
        var mockDependencyBuilderChainer = new MockDependencyBuilderChainer<TSut>(
            asserterCreator,
            namedDependencyBuilderCreator,
            null,
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
        
        mockDependencyBuilderChainer.Set(mockDependencyBuilderCreator);
        namedDependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        
        var mockObjectSetter = new MockObjectSetter<TObject>(
            arrangement
            );

        var sutAsserterCreator = new SutAsserterCreator<TSut>(
            sutComposer,
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
        
        var mockObjectBuilderCreator = new MockObjectBuilderCreator<TSut>(
            arrangement,
            sutAsserterCreator,
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            namedMockDependencyBuilderCreator,
            null
        );
        
        var objectBuilderChainer = new ObjectBuilderChainer<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            null,
            valueDependencyBuilderCreator,
            mockDependencyBuilderCreator,
            mockObjectBuilderCreator
        );

        var namedObjectBuilderChainer = new NamedObjectBuilderChainer<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            null,
            mockObjectBuilderCreator,
            mockDependencyBuilderCreator
        );

        var existingObjectBuilder = new ExistingObjectBuilder<TSut>(
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            null
        );
        
        var objectBuilderCreator = new ObjectBuilderCreator<TSut>(
            arrangement,
            objectBuilderChainer,
            namedObjectBuilderChainer,
            existingObjectBuilder
        );
        
        mockDependencyBuilderChainer.Set(objectBuilderCreator);
        existingObjectBuilder.Set(objectBuilderCreator);
        namedObjectBuilderChainer.Set(objectBuilderCreator);
        objectBuilderChainer.Set(objectBuilderCreator);
        mockObjectBuilderCreator.Set(objectBuilderCreator);
        
        var mockObjectBuilderChainer = new MockObjectBuilderChainer<TSut>(
            valueDependencyBuilderCreator,
            mockDependencyBuilderCreator,
            mockObjectBuilderCreator,
            objectBuilderCreator
        );
        
        return new MockObjectBuilder<TSut, TObject>(
            mock,
            mockObjectSetter,
            mockObjectBuilderChainer,
            arrangement
        );
    }
}