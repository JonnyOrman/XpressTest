namespace XpressTest;

public interface IMockDependencyBuilder<TSut, TDependency> : IDependencyBuilder<TSut>
{
    IMockDependencyBuilder<TSut, TDependency> ThatDoes<TDependencyResult>(
        Func<IArrangement, MockSetup<TDependency, TDependencyResult>> func
        );
}