using System.Linq.Expressions;

namespace XpressTest;

public interface IArrangementResultMockCountVerifierCreator<TMock, TAsserter>
    where TMock : class
{
    IMockCountVerifier<TAsserter> Create<TMockResult>(
        Func<IReadArrangement, Expression<Func<TMock, TMockResult>>> func,
        TAsserter asserter
    );
}