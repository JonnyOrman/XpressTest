using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementVoidMockCounterVerifierCreator<TMock, TAsserter>
{
    IMockCounterVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
    );
}