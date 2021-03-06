using System.Linq.Expressions;

namespace XpressTest;

public interface IVoidMockCallVerifierCreator<TMock, TAsserter>
{
    IMockCallVerifier<TAsserter> Create(
        Expression<Action<TMock>> expression
        );
}