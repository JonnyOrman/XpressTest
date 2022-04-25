namespace XpressTest;

public interface IDependencyBuilderCreator<TSut>
{
    IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(TNewDependency newDependency, string newDependencyName);
    
    IMockDependencySetupBuilder<TSut, TNewDependency> CreateMockDependencyBuilder<TNewDependency>()
        where TNewDependency : class;
    
    IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(TNewDependency newDependency);
    
    IDependencyBuilder<TSut> CreateObjectDependencyBuilder<TNewDependency>(Func<IReadArrangement, TNewDependency> newDependencyFunc);
    
    IMockDependencySetupBuilder<TSut, TNewDependency> CreateMockDependencyBuilder<TNewDependency>(string name)
        where TNewDependency : class;
    
    IMockDependencySetupBuilder<TSut, TMock> CreateExistingMockDependencyBuilder<TMock>()
        where TMock : class;
    
    IDependencyBuilder<TSut> Create<TObject>();
    
    IDependencyBuilder<TSut> Create<TObject>(
        string name
    );
}