using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementVoidMockCallVerifierCreator<TMock, TAsserter>
{
    IMockCallVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
        );
}