namespace XpressTest;

public class Container<TSut>
:
    IContainer<TSut>
where TSut : class
{
    public Container(
        IObjectDependencyBuilderCreator<TSut> objectDependencyBuilderCreator,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderCreator,
        IMockDependencyBuilderCreator<TSut> mockDependencyBuilderCreator,
        INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator,
        INamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderCreator,
        ITestBuilderContainer<TSut> testBuilderContainer
        )
    {
        ObjectDependencyBuilderCreator = objectDependencyBuilderCreator;
        MockSetupBuilderCreator = mockSetupBuilderCreator;
        MockDependencyBuilderCreator = mockDependencyBuilderCreator;
        NamedDependencyBuilderCreator = namedDependencyBuilderCreator;
        NamedMockSetupBuilderCreator = namedMockSetupBuilderCreator;
        TestBuilderContainer = testBuilderContainer;
    }
    
    public IObjectDependencyBuilderCreator<TSut> ObjectDependencyBuilderCreator { get; }
    
    public IMockSetupBuilderCreator<TSut> MockSetupBuilderCreator { get; }
    
    public IMockDependencyBuilderCreator<TSut> MockDependencyBuilderCreator { get; }
    
    public INamedDependencyBuilderCreator<TSut> NamedDependencyBuilderCreator { get; }
    
    public INamedMockSetupBuilderCreator<TSut> NamedMockSetupBuilderCreator { get; }
    
    public ITestBuilderContainer<TSut> TestBuilderContainer { get; }
}