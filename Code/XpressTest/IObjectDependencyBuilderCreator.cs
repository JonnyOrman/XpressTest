namespace XpressTest;

public interface IObjectDependencyBuilderCreator<TSut>
where TSut : class
{
    IDependencyBuilder<TSut> Create<TDependency>(
        TDependency dependency
    );

    IDependencyBuilder<TSut> Create<TDependency>(
        Func<IReadArrangement, TDependency> dependencyFunc
        );
}