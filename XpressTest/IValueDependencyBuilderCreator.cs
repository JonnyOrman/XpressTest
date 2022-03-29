namespace XpressTest;

public interface IValueDependencyBuilderCreator<TSut>
where TSut : class
{
    IValueDependencyBuilder<TSut> Create<TDependency>(
        TDependency dependency
    );
    
    IValueDependencyBuilder<TSut> Create<TDependency>(
        Func<IArrangement, TDependency> dependencyFunc
        );
}