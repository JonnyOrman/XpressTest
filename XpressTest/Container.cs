namespace XpressTest;

public class Container<TSut>
:
    IContainer<TSut>
where TSut : class
{
    public Container(
        IObjectDependencyBuilderCreator<TSut> objectDependencyBuilderCreator,
        IMockSetupBuilderCreator<TSut> mockSetupBuilderGenerator,
        IMoqMockDependencyBuilderCreator<TSut> moqMockDependencyBuilderCreator,
        INamedDependencyBuilderCreator<TSut> namedDependencyBuilderCreator,
        INamedMockSetupBuilderCreator<TSut> namedMockSetupBuilderCreator,
        ITestBuilderContainer<TSut> testBuilderContainer
        )
    {
        ObjectDependencyBuilderCreator = objectDependencyBuilderCreator;
        MockSetupBuilderGenerator = mockSetupBuilderGenerator;
        MoqMockDependencyBuilderCreator = moqMockDependencyBuilderCreator;
        NamedDependencyBuilderCreator = namedDependencyBuilderCreator;
        NamedMockSetupBuilderCreator = namedMockSetupBuilderCreator;
        TestBuilderContainer = testBuilderContainer;
    }
    
    public IObjectDependencyBuilderCreator<TSut> ObjectDependencyBuilderCreator { get; }
    
    public IMockSetupBuilderCreator<TSut> MockSetupBuilderGenerator { get; }
    
    public IMoqMockDependencyBuilderCreator<TSut> MoqMockDependencyBuilderCreator { get; }
    
    public INamedDependencyBuilderCreator<TSut> NamedDependencyBuilderCreator { get; }
    
    public INamedMockSetupBuilderCreator<TSut> NamedMockSetupBuilderCreator { get; }
    
    public ITestBuilderContainer<TSut> TestBuilderContainer { get; }
}