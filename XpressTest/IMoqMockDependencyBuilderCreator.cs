using Moq;

namespace XpressTest;

public interface IMoqMockDependencyBuilderCreator<TSut>
where TSut : class
{
    IMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        Mock<TDependency> moqMock
        )
        where TDependency : class;
    
    INamedMockDependencyBuilder<TSut, TDependency> Create<TDependency>(
        Mock<TDependency> moqMock,
        string name
    )
        where TDependency : class;
}