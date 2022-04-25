using System.Linq.Expressions;

namespace XpressTest;

public interface IResultMockCountVerifierCreator<TMock, TAsserter>
{
    IMockCountVerifier<TAsserter> Create<TMockResult>(
        Expression<Func<TMock, TMockResult>> expression
        );
}