namespace XpressTest;

public static class ValueDependencyBuilderChainerInitialiser<TSut>
where TSut : class
{
    public static IValueDependencyBuilderChainer<TSut> Initialise(
        ISutAsserterCreator<TSut> sutAsserterCreator,
        IVoidAsserterCreator<TSut> voidAsserterCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        INamedMockDependencyBuilderCreator<TSut> namedMockDependencyBuilderCreator
        )
    {
        return new ValueDependencyBuilderChainer<TSut>(
            sutAsserterCreator,
            voidAsserterCreator,
            mockDependencyBuilderCreator,
            namedMockDependencyBuilderCreator
            );
    }
}