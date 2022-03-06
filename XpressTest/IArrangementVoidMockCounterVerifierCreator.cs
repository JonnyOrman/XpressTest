using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementVoidMockCounterVerifierCreator<TMock, TAsserter>
{
    IMockCounterVerifier<TAsserter> Create(
        Func<IArrangement, Expression<System.Action<TMock>>> func,
        TAsserter asserter
    );
}