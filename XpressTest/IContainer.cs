namespace XpressTest;

public interface IContainer<TSut>
where TSut : class
{
    IObjectDependencyBuilderCreator<TSut> ObjectDependencyBuilderCreator { get; }
    
    IMockSetupBuilderCreator<TSut> MockSetupBuilderGenerator { get; }
    
    IMoqMockDependencyBuilderCreator<TSut> MoqMockDependencyBuilderCreator { get; }
    
    INamedDependencyBuilderCreator<TSut> NamedDependencyBuilderCreator { get; }
    
    INamedMockSetupBuilderCreator<TSut> NamedMockSetupBuilderCreator { get; }
    
    ITestBuilderContainer<TSut> TestBuilderContainer { get; }
}