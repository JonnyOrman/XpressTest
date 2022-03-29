namespace XpressTest;

public static class NamedMockObjectTestInitialiser<TSut, TObject>
    where TSut : class
    where TObject : class
{
    public static INamedMockObjectBuilder<TSut, TObject> Initialise(string mockName)
    {
        var namedMock = NamedMockInitialiser<TObject>.Initialise(mockName);

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

        existingObjectBuilder.Set(objectBuilderCreator);
        namedObjectBuilderChainer.Set(objectBuilderCreator);
        objectBuilderChainer.Set(objectBuilderCreator);
        mockObjectBuilderCreator.Set(objectBuilderCreator);
        
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
        
        mockDependencyBuilderChainer.Set(mockDependencyBuilderCreator);
        namedDependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        valueDependencyBuilderCreator.Set(mockDependencyBuilderCreator);
        existingObjectBuilder.Set(mockDependencyBuilderCreator);
        namedObjectBuilderChainer.Set(mockDependencyBuilderCreator);
        objectBuilderChainer.Set(mockDependencyBuilderCreator);
        mockObjectBuilderCreator.Set(mockDependencyBuilderCreator);
        
        var namedMockObjectSetter = new NamedMockObjectSetter<TObject>(
            arrangement
            );

        return new NamedMockObjectBuilder<TSut, TObject>(
            namedMock,
            arrangement,
            namedMockObjectSetter,
            voidAsserterCreator
        );
    }
}
