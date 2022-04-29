using System.Linq.Expressions;

namespace XpressTest;

public interface IAsyncResultMockVerifier<TSut, TSutResult, TMock>
{
    IMockCountVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
        );

    IMockCountVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func
    );

    IMockCountVerifier<IAsyncResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
    );
}