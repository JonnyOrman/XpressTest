namespace XpressTest;

public static class NamedObjectTestInitialiser<TSut, TObject>
    where TSut : class
{
    public static INamedObjectBuilder<TSut> Initialise(
        TObject obj,
        string objectName
        )
    {
        var namedObject = new NamedObject<TObject>(
            obj,
            objectName
        );

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
        
        var namedObjectSetter = new NamedObjectSetter<TObject>(
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
        
        var objectBuilderChainer = new ObjectBuilderChainer<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            null,
            valueDependencyBuilderCreator,
            mockDependencyBuilderCreator,
            null
        );

        var existingObjectBuilder = new ExistingObjectBuilder<TSut>(
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            null
        );
        
        var objectBuilderCreator = new ObjectBuilderCreator<TSut>(
            arrangement,
            objectBuilderChainer,
            null,
            existingObjectBuilder
        );

        existingObjectBuilder.Set(objectBuilderCreator);
        mockDependencyBuilderChainer.Set(objectBuilderCreator);
        objectBuilderChainer.Set(objectBuilderCreator);

        var mockObjectBuilderCreator = new MockObjectBuilderCreator<TSut>(
            arrangement,
            sutAsserterCreator,
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            namedMockDependencyBuilderCreator,
            objectBuilderCreator
        );
        
        objectBuilderChainer.Set(mockObjectBuilderCreator);

        var namedObjectBuilderChainer = new NamedObjectBuilderChainer<TSut>(
            voidAsserterCreator,
            resultAsserterCreator,
            objectBuilderCreator,
            mockObjectBuilderCreator,
            mockDependencyBuilderCreator
        );

        objectBuilderCreator.Set(namedObjectBuilderChainer);
        
        return new NamedObjectBuilder<TSut, TObject>(
            namedObject,
            namedObjectSetter,
            namedObjectBuilderChainer
        );
    }
}
