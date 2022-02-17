using System.Linq.Expressions;

namespace XpressTest;

public interface IMockDependencyBuilder<TSut, TDependency> : IDependencyBuilder<TSut>
{
    IMockDependencyBuilder<TSut, TDependency> That<TDependencyResult>(Expression<Func<TDependency, TDependencyResult>> func,
        TDependencyResult dependencyResult);
}