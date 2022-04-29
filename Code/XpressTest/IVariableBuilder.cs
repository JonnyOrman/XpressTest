namespace XpressTest;

public interface IVariableBuilder<TSut>
:
    IVariablesBuilder<TSut>,
    IDependenciesBuilder<TSut>,
    IActor<TSut>
{
    IDependencyBuilder<TSut> With<TNewDependency>(
        Func<IReadArrangement, TNewDependency> newDependencyFunc
    );
}