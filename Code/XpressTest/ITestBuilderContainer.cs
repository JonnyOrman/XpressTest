namespace XpressTest;

public interface ITestBuilderContainer<TSut>
where TSut : class
{
    IAsserterCreator<TSut> AsserterCreator { get; }
    IVariableBuilderCreator<TSut> VariableBuilderCreator { get; }
    IDependencyBuilderCreator<TSut> DependencyBuilderCreator { get; }
}