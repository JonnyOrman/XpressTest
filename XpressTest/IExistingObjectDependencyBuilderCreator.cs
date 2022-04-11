namespace XpressTest;

public interface IExistingObjectDependencyBuilderCreator<TSut>
{
    IDependencyBuilder<TSut> Create<TDependency>();
    
    IDependencyBuilder<TSut> Create<TDependency>(string name);
}