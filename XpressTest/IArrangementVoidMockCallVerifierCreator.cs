using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementVoidMockCallVerifierCreator<TMock, TAsserter>
{
    IMockCallVerifier<TAsserter> Create(
        Func<IArrangement, Expression<System.Action<TMock>>> func,
        TAsserter asserter
        );
}