using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockCounterVerifierCreator<TMock, TAsserter>
{
    IMockCounterVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
}