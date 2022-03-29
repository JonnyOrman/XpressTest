using System.Linq.Expressions;

namespace XpressTest;

public interface INamedMockDependencyBuilder<TSut, TDependency>
{
    IResultAsserter<TSut, TResult> WhenIt<TResult>(
        Func<IAction<TSut>, TResult> func
    );

    INamedMockDependencyBuilder<TSut, TNewDependency> WithA<TNewDependency>(
        string name
    )
        where TNewDependency : class;

    INamedMockResultDependencyBuilder<TSut, TDependency, TResult> ThatDoes<TResult>(
        Func<IArrangement, Expression<Func<TDependency, TResult>>> func
    );
}