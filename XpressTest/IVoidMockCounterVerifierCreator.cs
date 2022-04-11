using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockCounterVerifierCreator<TMock, TAsserter>
{
    IMockCounterVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
        );
}