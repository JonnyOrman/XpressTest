namespace XpressTest;

public class TestBuilderContainer<TSut>
:
    ITestBuilderContainer<TSut>
where TSut : class
{
    public TestBuilderContainer(
        IAsserterCreator<TSut> asserterCreator
        )
    {
        AsserterCreator = asserterCreator;
    }

    public IAsserterCreator<TSut> AsserterCreator { get; }
    public IVariableBuilderCreator<TSut> VariableBuilderCreator { get; set; }
    public IDependencyBuilderCreator<TSut> DependencyBuilderCreator { get; set; }
}