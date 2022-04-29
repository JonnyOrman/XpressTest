using System.Linq.Expressions;

namespace XpressTest;

public interface IMockDependencySetupBuilder<TSut, TObject>
:
    IDependencyBuilder<TSut>
{
    IMockResultBuilder<TResult, IDependencyBuilder<TSut>> ThatDoes<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, TResult>>> func
    );

    IMockResultBuilder<TResult, IDependencyBuilder<TSut>> ThatDoes<TResult>(
        Expression<Func<TObject, TResult>> expression
    );

    IMockAsyncResultDependencyBuilder<TSut, TResult> ThatDoesAsync<TResult>(
        Func<IReadArrangement, Expression<Func<TObject, Task<TResult>>>> func
    );

    IMockAsyncResultDependencyBuilder<TSut, TResult> ThatDoesAsync<TResult>(
        Expression<Func<TObject, Task<TResult>>> expression
    );
}