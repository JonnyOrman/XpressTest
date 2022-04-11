using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementResultMockCounterVerifierCreator<TMock, TAsserter>
    where TMock : class
{
    IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
    );
}