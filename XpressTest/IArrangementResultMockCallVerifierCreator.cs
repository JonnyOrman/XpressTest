using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementResultMockCallVerifierCreator<TMock, TAsserter>
{
    IMockCallVerifier<TAsserter> Create<TMockResult>(
        Func<IArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
        );
}