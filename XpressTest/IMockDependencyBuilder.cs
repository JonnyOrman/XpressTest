using System.Linq.Expressions;

namespace XpressTest;

public interface IMockDependencyBuilder<TSut, TDependency> : IDependencyBuilder<TSut>
{
    IMockDependencyBuilder<TSut, TDependency> That<TDependencyResult>(
        Func<IArrangement, MockSetup<TDependency, TDependencyResult>> func
        );
}