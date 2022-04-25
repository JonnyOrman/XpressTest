namespace XpressTest;

public interface IContainer<TSut>
where TSut : class
{
    IObjectDependencyBuilderCreator<TSut> ObjectDependencyBuilderCreator { get; }
    
    IMockSetupBuilderCreator<TSut> MockSetupBuilderCreator { get; }
    
    IMockDependencyBuilderCreator<TSut> MockDependencyBuilderCreator { get; }
    
    INamedDependencyBuilderCreator<TSut> NamedDependencyBuilderCreator { get; }
    
    INamedMockSetupBuilderCreator<TSut> NamedMockSetupBuilderCreator { get; }
    
    ITestBuilderContainer<TSut> TestBuilderContainer { get; }
}