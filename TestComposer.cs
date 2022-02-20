namespace XpressTest;

public class TestComposer<TSut> : ITestComposer
{
    private readonly IAsserterComposer<TSut> _asserterComposer;
    private readonly IMockDependencyAsserterComposer<TSut> _mockDependencyAsserterComposer;
    private readonly IDependencyAsserterComposer<TSut> _dependencyAsserterComposer;
    private readonly IDependencyBuilderComposer<TSut> _dependencyBuilderComposer;
    private readonly IMockDependencyBuilderComposer<TSut> _mockDependencyBuilderComposer;

    public TestComposer(
        IAsserterComposer<TSut> asserterComposer,
        IMockDependencyAsserterComposer<TSut> mockDependencyAsserterComposer,
        IDependencyAsserterComposer<TSut> dependencyAsserterComposer,
        IDependencyBuilderComposer<TSut> dependencyBuilderComposer,
        IMockDependencyBuilderComposer<TSut> mockDependencyBuilderComposer
    )
    {
        
    }
}