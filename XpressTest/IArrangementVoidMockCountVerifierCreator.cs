using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementVoidMockCountVerifierCreator<TMock, TAsserter>
{
    IMockCountVerifier<TAsserter> Create(
        Func<IReadArrangement, Expression<Action<TMock>>> func,
        TAsserter asserter
    );
}