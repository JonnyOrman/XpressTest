using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockCountVerifierCreator<TMock, TAsserter>
{
    IMockCountVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
        );
}