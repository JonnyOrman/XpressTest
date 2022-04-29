using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockVerifier<TSut, TSutResult, TMock>
{
    IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func
        );

    IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );

    IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Func<IReadArrangement, Expression<Action<TMock>>> func
    );

    IMockCountVerifier<IResultAsserter<TSut, TSutResult>> Should(
        Expression<Action<TMock>> expression
    );
}